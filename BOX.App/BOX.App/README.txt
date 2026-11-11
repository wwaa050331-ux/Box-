[수정 대상]
BOX.App/BOX.App/DBHelper.cs
BOX.App/BOX.App/ParcelForm.cs

[적용 방법]
1. Visual Studio를 종료합니다.
2. 압축 파일 안의 두 .cs 파일을 저장소의 BOX.App/BOX.App/ 폴더에 덮어씁니다.
3. Visual Studio에서 프로젝트를 다시 열고 빌드합니다.
4. Git 변경 내용에서 두 파일을 커밋하고 Push합니다.

[수정 내용]
- ExecuteNonQuery가 INSERT/UPDATE 후 Oracle transaction을 Commit하도록 수정
- 보관 신청 중복 클릭 방지
- 보관함 상태 변경 결과가 0건이면 실패로 안내

[실행 전 확인]
- box.sql을 BOX 계정으로 실행했는지
- seq_parcel_id가 존재하는지
- Users에 user01이 존재하는지
- Lockers에 status='EMPTY'인 보관함이 있는지
- Oracle.DataAccess.dll 참조와 DBHelper 접속 정보가 맞는지
