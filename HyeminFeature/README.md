# 혜민 담당 기능

이 폴더는 혜민 담당 기능만 포함합니다.

- `LockerForm.cs`: 지점별 보관함 조회, 빈 보관함 선택
- `ParcelForm.cs`: 보관 신청, 6자리 인증번호 발급·복사, 택배기사 투입 완료 처리

## 현재 저장소 상태

현재 저장소에는 아직 `.sln`/`.csproj` Visual Studio 프로젝트가 없고, `DBHelper.cs`와 `box.sql`이 먼저 올라와 있습니다. 따라서 Visual Studio에서 프로젝트를 만든 뒤 아래 두 `.cs` 파일을 **기존 항목으로 추가**해야 합니다.

## Visual Studio에서 추가하는 순서

1. `.NET Framework 4.7.2` Windows Forms 프로젝트를 연다.
2. 솔루션 탐색기에서 프로젝트를 우클릭한다.
3. `추가` → `기존 항목`을 선택한다.
4. 이 폴더의 `LockerForm.cs`, `ParcelForm.cs`를 선택한다.
5. 프로젝트의 기본 네임스페이스가 `BOX.App`인지 확인한다.
6. 기존 `DBHelper.cs`가 같은 프로젝트에 포함되어 있는지 확인한다.

`ParcelForm`은 로그인한 사용자의 ID를 생성자로 전달해서 연다.

```csharp
using (ParcelForm form = new ParcelForm(currentUserId))
{
    form.ShowDialog(this);
}
```

## Oracle.DataAccess.Client 연결 준비

`DBHelper.cs`가 이미 `Oracle.DataAccess.Client`를 사용하고 있습니다. 각 팀원의 컴퓨터에는 다음이 준비되어 있어야 합니다.

- Oracle Client 또는 Oracle Data Access Components(ODAC)
- 프로젝트가 참조하는 `Oracle.DataAccess.dll`
- Oracle 접속 정보: HOST, PORT, SERVICE_NAME, USER_ID, PASSWORD

Visual Studio에서 `참조` → `참조 추가` → `찾아보기`로 팀에서 정한 `Oracle.DataAccess.dll`을 추가합니다. 팀원이 모두 같은 Oracle Client 버전과 32비트/64비트 설정을 사용해야 합니다.

현재 `DBHelper.cs`의 기본 접속 설정은 다음 값입니다.

```text
HOST: localhost
PORT: 1521
SERVICE_NAME: xe
USER_ID: box
```

비밀번호나 개인 접속 정보는 GitHub에 새로 올리지 않습니다. 팀에서 정한 로컬 DB 설정과 `DBHelper.cs`의 접속 정보가 다르면 각자 로컬에서 맞추고, 실제 비밀번호는 커밋하지 않습니다.

## DB 초기화

Oracle SQL Developer 또는 SQL*Plus에서 `box.sql`을 실행합니다. 이 스크립트는 기존 테이블을 삭제하고 다시 생성하므로, 중요한 데이터가 있는 DB에서 실행하면 안 됩니다.

필요한 테이블은 다음과 같습니다.

```text
Users
Branches
Lockers
Parcels
SystemLogs
```

`Lockers.status`는 현재 다음 값을 사용합니다.

```text
EMPTY      빈 보관함
RESERVED   보관 신청 완료, 택배 투입 대기
OCCUPIED   택배 보관 중
BROKEN     고장
```

`Parcels.status`는 다음 값을 사용합니다.

```text
RESERVED   보관 신청 완료
STORED     택배 투입 완료
RETRIEVED  택배 수령 완료
EXPIRED    기간 만료
```

## 혜민 담당 기능의 흐름

```text
지점 조회
→ 빈 보관함 조회
→ 보관함 선택
→ 택배 보관 신청
→ Parcels 등록
→ Lockers 상태 EMPTY → RESERVED
→ 인증번호 복사
→ 택배기사 투입 완료
→ Parcels 상태 RESERVED → STORED
→ Lockers 상태 RESERVED → OCCUPIED
```

현재 `Parcels` 테이블에는 택배 이름/설명 컬럼이 없으므로, 이 구현은 기존 스키마에 맞춰 사용자·보관함·인증번호·상태·일시를 등록합니다. 택배 이름이나 송장번호를 추가하려면 먼저 팀 전체가 ERD와 `box.sql`을 함께 수정해야 합니다.
