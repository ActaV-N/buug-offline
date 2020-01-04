# Buug Offline

버억 오프라인 게임 개발 협업을 위한 깃허브 페이지입니다.

---

## Git Hub 환경 설정

우선 아래 링크를 통해서 깃허브를 설치해줍니다.
[깃허브 설치](https://coding-factory.tistory.com/245)

---

## 협업을 위한 기본 개념

지금 보고있는 이 Github 페이지를 *원격 저장소*라고 부릅니다. 이 저장소를 복사(clone)해서 자신의 컴퓨터에 다운로드 받으면 다운로드 받은 폴더는 *로컬 저장소*가 됩니다.

각 팀원들은 자신들의 *로컬 저장소*를 유니티를 통해 열어서 개발을 하고 개발한 내용을 *원격 저장소*에 반영하면 됩니다.

_단, 역할을 확실하게 분리해야 로컬 저장소의 변경내용을 원격 저장소에 반영할 때 오류없이 반영할 수 있습니다._

> 예를들어, player의 움직임을 다루는 script를 만든다고 가정합시다.
> 팀원 1이 playerMovemet.cs로 스크립트를 올리고, 팀원 2가 같은 이름으로 스크립트를 올리면 두 파일의 내용을 합치거나(_코드 중복 우려_, _로직 오류 우려_) 파일 하나로 결정해야합니다. 누군가는 시간 낭비를 하게 된거죠.

또한, 같은 기능을하는 cs파일을 2개 만들어도 시간낭비를 하게 됩니다. 이를 방지하기 위해서 철저한 역할 분담이 필요하며 *원격 저장소*의 최신 내용을 자주 반영해주는게 좋습니다.

~~나도 깃허브로 협업 많이 안해봐서 모르지만 하튼 그럴거임 ㅇㅇ~~

---

## 협업을 위한 명령어와 단계

*로컬 저장소*의 내용을 *원격 저장소*에 반영을 하거나, *원격 저장소*의 내용을 자신의 컴퓨터에 다운로드해서 *로컬 저장소*를 만드는 일을 하기 위해 명령어들을 알아두면 편합니다.

우선 기본적으로 명령 프롬프트에서 사용할 명령어 딱 2가지만 알아봅시다.(window)

1. tree - 현재 디렉토리에서 이동할 수 있는 폴더들을 보여줍니다.(아마)
2. cd - 지정한 디렉토리로 이동합니다.

자 예를들어 현재 경로가 desktop이고, 안에 unity, game이라는 두가지 폴더가 있다고 합시다.
그럼 tree 명령어를 입력하면

> unity
> game

를 출력할꺼에요(아마)

그리고 unity폴더로 이동하고 싶으면 `cd unity`명령어를 입력하면 되죠.

위의 두가지 명령어를 이용해서 cmd로 *로컬 저장소*로 만들 폴더로 이동해주세요.

### Git 명령어

자 이제 해당 저장소를 *로컬 저장소*로 만들고 *원격 저장소*를 복사(clone)해와야합니다.

> git init

명령어를 이용해서 *로컬 저장소*로 만든 뒤 다음 명령어를 통해 *원격 저장소*를 복사해줍니다.
아아 귀찮으니까 다음에 나머지 작성함
