-- ==========================================================
-- 무인 택배함 관리 시스템 DB 초기화 및 생성 스크립트
-- 기능도 및 ERD 최종 반영본
-- ==========================================================

-- 1. 기존 테이블 및 시퀀스 삭제 (참조 무결성 역순: 자식 -> 부모)
DROP TABLE SystemLogs CASCADE CONSTRAINTS PURGE
/
DROP TABLE Parcels CASCADE CONSTRAINTS PURGE
/
DROP TABLE Lockers CASCADE CONSTRAINTS PURGE
/
DROP TABLE Branches CASCADE CONSTRAINTS PURGE
/
DROP TABLE Users CASCADE CONSTRAINTS PURGE
/

DROP SEQUENCE seq_branch_id
/
DROP SEQUENCE seq_locker_id
/
DROP SEQUENCE seq_parcel_id
/
DROP SEQUENCE seq_log_id
/

-- ==========================================================
-- 2. 시퀀스 생성
-- ==========================================================
CREATE SEQUENCE seq_branch_id START WITH 1 INCREMENT BY 1 NOCACHE
/
CREATE SEQUENCE seq_locker_id START WITH 101 INCREMENT BY 1 NOCACHE
/
CREATE SEQUENCE seq_parcel_id START WITH 1 INCREMENT BY 1 NOCACHE
/
CREATE SEQUENCE seq_log_id    START WITH 1 INCREMENT BY 1 NOCACHE
/

-- ==========================================================
-- 3. 테이블 생성 (ERD 구조 일치)
-- ==========================================================

-- 1) 사용자 테이블 (Users)
CREATE TABLE Users (
    user_id     VARCHAR2(20) PRIMARY KEY,
    name        VARCHAR2(50) NOT NULL,
    phone       VARCHAR2(20) NOT NULL,
    password    VARCHAR2(100) NOT NULL,
    role        VARCHAR2(20) DEFAULT 'USER',
    status      VARCHAR2(20) DEFAULT 'ACTIVE',
    CONSTRAINT chk_user_role CHECK (role IN ('USER', 'ADMIN', 'COURIER')),
    CONSTRAINT chk_user_status CHECK (status IN ('ACTIVE', 'INACTIVE', 'BANNED'))
)
/

-- 2) 지점 테이블 (Branches)
CREATE TABLE Branches (
    branch_id   NUMBER PRIMARY KEY,
    branch_name VARCHAR2(100) NOT NULL,
    address     VARCHAR2(200),
    contact     VARCHAR2(20)
)
/

-- 3) 보관함 테이블 (Lockers)
CREATE TABLE Lockers (
    locker_id     NUMBER PRIMARY KEY,
    branch_id     NUMBER,
    locker_size   VARCHAR2(10),                   -- ERD의 size (오라클 예약어 충돌 방지)
    location_desc VARCHAR2(100),
    status        VARCHAR2(20) DEFAULT 'EMPTY',
    CONSTRAINT fk_locker_branch FOREIGN KEY (branch_id) REFERENCES Branches(branch_id) ON DELETE SET NULL,
    CONSTRAINT chk_locker_status CHECK (status IN ('EMPTY', 'OCCUPIED', 'BROKEN'))
)
/

-- 4) 택배 보관 테이블 (Parcels)
CREATE TABLE Parcels (
    parcel_id    NUMBER PRIMARY KEY,
    user_id      VARCHAR2(20),
    locker_id    NUMBER,
    auth_code    VARCHAR2(10),                    -- ERD의 인증번호
    stored_at    DATE DEFAULT SYSDATE,
    expired_at   DATE,
    retrieved_at DATE,
    status       VARCHAR2(20) DEFAULT 'RESERVED',
    CONSTRAINT fk_parcel_user FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE SET NULL,
    CONSTRAINT fk_parcel_locker FOREIGN KEY (locker_id) REFERENCES Lockers(locker_id) ON DELETE SET NULL,
    CONSTRAINT chk_parcel_status CHECK (status IN ('RESERVED', 'STORED', 'RETRIEVED', 'EXPIRED'))
)
/

-- 5) 시스템 기록 테이블 (SystemLogs) - ERD의 FK 관계 완벽 반영
CREATE TABLE SystemLogs (
    log_id      NUMBER PRIMARY KEY,
    user_id     VARCHAR2(20),
    locker_id   NUMBER,
    type        VARCHAR2(30),
    description VARCHAR2(200),
    created_at  DATE DEFAULT SYSDATE,
    CONSTRAINT fk_log_user FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE SET NULL,
    CONSTRAINT fk_log_locker FOREIGN KEY (locker_id) REFERENCES Lockers(locker_id) ON DELETE SET NULL
)
/

-- ==========================================================
-- 4. 초기 샘플 데이터 입력 (테이블당 5개 튜플)
-- ==========================================================

-- 1) Users 샘플 데이터 (기능도: 관리자, 사용자, 기사)
INSERT INTO Users VALUES ('admin', '시스템관리자', '010-0000-0000', 'admin1234', 'ADMIN', 'ACTIVE')
/
INSERT INTO Users VALUES ('courier01', '김기사', '010-1111-2222', 'courier123', 'COURIER', 'ACTIVE')
/
INSERT INTO Users VALUES ('user01', '홍길동', '010-2222-3333', 'pass01', 'USER', 'ACTIVE')
/
INSERT INTO Users VALUES ('user02', '이순신', '010-4444-5555', 'pass02', 'USER', 'ACTIVE')
/
INSERT INTO Users VALUES ('user03', '강감찬', '010-6666-7777', 'pass03', 'USER', 'ACTIVE')
/

-- 2) Branches 샘플 데이터 (기능도: 지점 목록 및 위치 조회)
INSERT INTO Branches VALUES (1, '부천대 본관점', '경기도 부천시 신흥로 56', '032-610-0114')
/
INSERT INTO Branches VALUES (2, '한길체육관점', '경기도 부천시 신흥로 56 한길관', '032-610-0115')
/
INSERT INTO Branches VALUES (3, '부천역 환승센터점', '경기도 부천시 부천로 1', '032-650-1234')
/
INSERT INTO Branches VALUES (4, '송내역 북부광장점', '경기도 부천시 송내대로 43', '032-660-5678')
/
INSERT INTO Branches VALUES (5, '신중동역점', '경기도 부천시 길주로 300', '032-320-9999')
/

-- 3) Lockers 샘플 데이터 (기능도: 잔여함/상태 관리, 보관함 크기)
INSERT INTO Lockers VALUES (101, 1, 'M', '본관 1층 무인택배 부스', 'EMPTY')
/
INSERT INTO Lockers VALUES (102, 1, 'L', '본관 1층 무인택배 부스', 'OCCUPIED')
/
INSERT INTO Lockers VALUES (103, 1, 'S', '본관 1층 무인택배 부스', 'OCCUPIED')
/
INSERT INTO Lockers VALUES (104, 2, 'M', '체육관 입구 경비실 옆', 'BROKEN')
/
INSERT INTO Lockers VALUES (105, 3, 'L', '지하 1층 2번 출구', 'EMPTY')
/

-- 4) Parcels 샘플 데이터 (기능도: 인증번호 발급/확인, 보관/수령 상태)
INSERT INTO Parcels VALUES (1, 'user01', 101, '1234', TO_DATE('2026-11-08 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-11 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-08 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'RETRIEVED')
/
INSERT INTO Parcels VALUES (2, 'user02', 102, '5678', TO_DATE('2026-11-09 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-12 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'STORED')
/
INSERT INTO Parcels VALUES (3, 'user03', 103, '9012', TO_DATE('2026-11-09 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-12 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'STORED')
/
INSERT INTO Parcels VALUES (4, 'user01', 101, '3344', TO_DATE('2026-11-05 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-08 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'EXPIRED')
/
INSERT INTO Parcels VALUES (5, 'user02', 105, '7788', TO_DATE('2026-11-09 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2026-11-12 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'RESERVED')
/

-- 5) SystemLogs 샘플 데이터 (기능도: 오류 및 시스템 기록 관리)
INSERT INTO SystemLogs VALUES (1, 'courier01', 101, 'STORE', '택배 보관 완료 (101호)', TO_DATE('2026-11-08 09:00:00', 'YYYY-MM-DD HH24:MI:SS'))
/
INSERT INTO SystemLogs VALUES (2, 'user01', 101, 'RETRIEVE', '인증번호 일치 및 택배 수령 완료', TO_DATE('2026-11-08 18:30:00', 'YYYY-MM-DD HH24:MI:SS'))
/
INSERT INTO SystemLogs VALUES (3, 'courier01', 102, 'STORE', '택배 보관 완료 (102호)', TO_DATE('2026-11-09 10:00:00', 'YYYY-MM-DD HH24:MI:SS'))
/
INSERT INTO SystemLogs VALUES (4, 'admin', NULL, 'LOGIN', '관리자 대시보드 로그인', TO_DATE('2026-11-09 12:00:00', 'YYYY-MM-DD HH24:MI:SS'))
/
INSERT INTO SystemLogs VALUES (5, 'user01', 104, 'ERROR', '보관함 문 열림 센서 오류 감지', TO_DATE('2026-11-09 14:00:00', 'YYYY-MM-DD HH24:MI:SS'))
/

COMMIT
/

-- ==========================================================
-- 5. 출력 포맷 설정 및 검증 SELECT 문
-- ==========================================================
SET LINESIZE 150
SET PAGESIZE 50

COL user_id FORMAT A10
COL name FORMAT A12
COL phone FORMAT A14
COL role FORMAT A8
COL status FORMAT A10
COL branch_name FORMAT A18
COL address FORMAT A28
COL contact FORMAT A14
COL locker_size FORMAT A6
COL location_desc FORMAT A22
COL auth_code FORMAT A8
COL description FORMAT A35

PROMPT [ 1. Users 테이블 조회 ]
SELECT * FROM Users;

PROMPT [ 2. Branches 테이블 조회 ]
SELECT * FROM Branches;

PROMPT [ 3. Lockers 테이블 조회 ]
SELECT * FROM Lockers;

PROMPT [ 4. Parcels 테이블 조회 ]
SELECT parcel_id, user_id, locker_id, auth_code, status, TO_CHAR(stored_at, 'YYYY-MM-DD HH24:MI') AS stored, TO_CHAR(retrieved_at, 'YYYY-MM-DD HH24:MI') AS retrieved FROM Parcels;

PROMPT [ 5. SystemLogs 테이블 조회 ]
SELECT log_id, user_id, locker_id, type, description, TO_CHAR(created_at, 'YYYY-MM-DD HH24:MI:SS') AS created FROM SystemLogs;