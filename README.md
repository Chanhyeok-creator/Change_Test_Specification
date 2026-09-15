# Change Test Specification

자동차 관련 부품 검사 장비에서 사용하는 **Test Specification XML 파일을 관리하기 위한 Windows Forms 기반 프로그램**입니다.

C#과 XML을 이용하여 검사 항목을 `DataGridView`에서 조회하고 수정할 수 있으며, XML 파일의 생성·로드·저장·삭제 기능을 제공합니다.

---

## 📌 프로젝트 소개

본 프로젝트는 검사 장비에서 사용되는 Test Specification 데이터를 보다 편리하게 관리하기 위해 제작되었습니다.

검사 조건을 XML 파일로 관리하며, 프로그램에서는 XML 데이터를 `DataGridView` 형태로 표시합니다.

사용자는 Editor 화면에서 검사 항목을 추가하거나 삭제하고, `Min`, `Max`, `Voltage` 등의 값을 수정한 후 XML 파일로 저장할 수 있습니다.

### 주요 목적

* 검사 Specification 데이터의 XML 기반 관리
* 검사 항목의 조회 및 수정
* Test Case XML 파일 생성 및 삭제
* 검사 데이터의 입력값 검증
* XML 파일 경로 관리

---

## 🛠 개발 환경

| 항목              | 내용                 |
| --------------- | ------------------ |
| Language        | C#                 |
| Framework       | .NET Framework     |
| IDE             | Visual Studio 2012 |
| Application     | Windows Forms      |
| Data Format     | XML                |
| Version Control | Git / GitHub       |

---

## 📂 프로젝트 구조

```text
Change_Test_Specification/
│
├─ Change_Test_Specification.sln
│
└─ Change_Test_Specification/
    │
    ├─ App.config
    ├─ Change_Test_Specification.csproj
    ├─ Program.cs
    │
    ├─ Classes/
    │   ├─ Data_save.cs
    │   ├─ FileManager.cs
    │   └─ Make_New_XML.cs
    │
    ├─ Forms/
    │   ├─ Main_form1.cs
    │   ├─ Main_form1.Designer.cs
    │   ├─ Main_form1.resx
    │   │
    │   ├─ Editor_form2.cs
    │   ├─ Editor_form2.Designer.cs
    │   ├─ Editor_form2.resx
    │   │
    │   └─ Controls/
    │       ├─ DataGridView_Setting.cs
    │       ├─ DataGridView_Setting.Designer.cs
    │       └─ DataGridView_Setting.resx
    │
    ├─ Properties/
    │   ├─ AssemblyInfo.cs
    │   ├─ Resources.Designer.cs
    │   ├─ Resources.resx
    │   ├─ Settings.Designer.cs
    │   └─ Settings.settings
    │
    └─ res/
        └─ xml/
            ├─ path.xml
            ├─ testcase.xml
            └─ testcase_2.xml
```

> `bin/`, `obj/` 폴더는 Visual Studio 빌드 과정에서 생성되는 파일을 포함하므로 Git 저장소에서는 제외하는 것을 권장합니다.

---

# 🖥 주요 기능

## 1. Test Specification 조회

프로그램을 실행하면 `Main_form1`에서 현재 설정된 XML 파일을 자동으로 불러옵니다.

XML의 각 `Data` 노드를 읽어 `DataGridView`에 표시합니다.

표시되는 주요 데이터는 다음과 같습니다.

| 항목             | 설명       |
| -------------- | -------- |
| Test_name      | 검사 항목 이름 |
| Min            | 최소 허용값   |
| Max            | 최대 허용값   |
| Voltage        | 검사 전압    |
| Measured_value | 측정값      |
| Result         | 검사 결과    |

Main 화면에서는 데이터를 **Read Only 상태**로 표시하여 검사 Specification을 조회할 수 있습니다.

---

## 2. Test Specification 수정

Editor 화면에서는 XML 데이터를 수정할 수 있습니다.

Editor 화면에서 파일을 Load하면 `DataGridView`의 `ReadOnly` 속성이 `false`로 설정되어 데이터를 수정할 수 있습니다.

### 제공되는 기능

* XML 파일 Load
* 검사 항목 추가
* 검사 항목 삭제
* 데이터 수정
* XML 저장

---

## 3. XML 파일 생성

`FileManager`의 `create_file_button()`을 통해 새로운 XML 파일을 생성할 수 있습니다.

파일 저장 위치를 사용자가 지정하면 `Make_New_XML`에서 기본적인 XML 구조를 생성합니다.

생성되는 기본 구조는 다음과 같습니다.

```xml
<Test>
    <Data id="0">
        <Test_name></Test_name>
        <Min></Min>
        <Max></Max>
        <Voltage></Voltage>
        <Measured_value></Measured_value>
        <Result></Result>
    </Data>
</Test>
```

---

## 4. XML 파일 Load

사용자가 XML 파일을 선택하면 선택한 파일의 경로를 `path.xml`에 저장합니다.

```xml
<Path_List>
    <path>XML 파일 경로</path>
</Path_List>
```

이후 `DataGridView_Setting`에서 `path.xml`을 읽어 실제 Test Specification XML 파일의 위치를 확인합니다.

---

## 5. XML 파일 저장

Editor에서 수정한 데이터는 Save 기능을 통해 XML 파일에 저장됩니다.

저장 과정에서는 기존 `/Test` 노드의 데이터를 제거한 후 `DataGridView`의 데이터를 기준으로 새로운 `Data` 노드를 생성합니다.

각 `Data`에는 다음과 같은 데이터가 저장됩니다.

```xml
<Data id="0">
    <Test_name>...</Test_name>
    <Min>...</Min>
    <Max>...</Max>
    <Voltage>...</Voltage>
    <Measured_value>...</Measured_value>
    <Result>...</Result>
</Data>
```

`id`는 DataGridView의 행 번호를 기준으로 생성됩니다.

---

# ✅ 데이터 유효성 검사

XML 저장 시 일부 입력값에 대한 유효성 검사를 수행합니다.

## 숫자 형식 검사

다음 항목은 숫자로 입력되어야 합니다.

```text
Min
Max
Voltage
```

숫자가 아닌 값이 입력되면 오류 메시지를 표시하고 저장을 중단합니다.

```text
Min,Max,Voltage에는 숫자가 들어가야 합니다.
```

---

## Min / Max 범위 검사

`Min`과 `Max`가 모두 입력된 경우 다음 조건을 확인합니다.

```text
Min < Max
```

다음과 같은 경우 저장할 수 없습니다.

```text
Min >= Max
```

오류 발생 시 다음 메시지를 표시합니다.

```text
Min과 Max를 확인해주세요.
```

---

# 🧩 클래스 및 파일 역할

## `Main_form1.cs`

프로그램의 메인 화면을 담당합니다.

주요 역할:

* `DataGridView_Setting` 표시
* Test Specification 조회
* XML 파일 이름 표시
* Editor 화면 실행
* Editor 종료 후 데이터 새로고침

주요 메서드:

```csharp
LoadMeasuredSpecList()
editor_button_Click()
```

---

## `Editor_form2.cs`

Test Specification을 편집하는 Editor 화면입니다.

주요 기능:

* XML 파일 Load
* XML 파일 생성
* XML 파일 삭제
* 데이터 추가
* 데이터 삭제
* 데이터 저장

`ON_OFF` 변수를 이용하여 XML 파일이 Load된 이후에만 데이터 추가/삭제/저장이 가능하도록 제어합니다.

---

## `DataGridView_Setting.cs`

실제 Test Specification 데이터를 `DataGridView`에 표시하고 관리하는 UserControl입니다.

주요 역할:

* XML 파일 읽기
* XML 데이터 → DataGridView 변환
* 파일 경로 확인
* 행 추가
* 행 삭제
* 데이터 읽기
* 데이터 초기화
* 현재 XML 파일 이름 반환

주요 메서드:

```csharp
path_setting()
DataGrid_Column()
Clear_Table1()
Count_Table1_Row()
Read_Table_data()
Add_row()
Delete_row()
Return_filename()
```

---

## `FileManager.cs`

파일 관련 작업을 담당합니다.

주요 기능:

```text
XML 파일 생성
XML 파일 삭제
XML 파일 열기
XML 파일 저장
```

주요 메서드:

```csharp
create_file_button()
delete_file_button()
open_file_button()
Save_button()
```

---

## `Make_New_XML.cs`

새로운 XML 파일을 생성하고 XML 파일 경로를 관리합니다.

주요 역할:

* 기본 Test Specification XML 생성
* `path.xml` 생성
* 기본 XML 구조 생성

주요 메서드:

```csharp
make_new_xml()
make_new_path_xml()
make_real_new_xml()
change_xml_file_name()
```

> `change_xml_file_name()`은 현재 메서드만 정의되어 있으며 실제 파일명 변경 로직은 구현되어 있지 않습니다.

---

## `Data_save.cs`

### `TestCaseModel`

Test Case 데이터를 임시로 관리하는 Model 클래스입니다.

관리하는 데이터:

```text
id
testname
Min
Max
Voltage
MeasuredValue
Result
file_path
```

`datalist()`를 이용하여 현재 Test Case 데이터를 리스트에 저장하고, `datacontrol()`과 `dataout()`을 통해 데이터를 수정하거나 가져옵니다.

---

# 🔄 프로그램 동작 구조

전체적인 데이터 흐름은 다음과 같습니다.

```text
                  ┌─────────────────┐
                  │   Main_form1     │
                  │   메인 화면      │
                  └────────┬────────┘
                           │
                           ▼
                ┌──────────────────────┐
                │ DataGridView_Setting │
                │   XML 데이터 표시     │
                └──────────┬───────────┘
                           │
                           ▼
                     ┌───────────┐
                     │ path.xml  │
                     └─────┬─────┘
                           │
                           ▼
                    Testcase.xml
```

Editor에서 데이터를 수정하는 경우:

```text
Editor_form2
      │
      ├── Load
      │     ↓
      │ FileManager
      │     ↓
      │ DataGridView_Setting
      │     ↓
      │   XML 파일
      │
      ├── Add / Delete
      │     ↓
      │ DataGridView
      │
      └── Save
            ↓
       FileManager
            ↓
      TestCaseModel
            ↓
        XML 파일
```

---

# 📄 XML 구조

본 프로젝트에서는 두 종류의 XML 데이터를 사용합니다.

## `path.xml`

현재 사용 중인 Test Specification XML 파일의 경로를 저장합니다.

```xml
<Path_List>
    <path>...</path>
</Path_List>
```

---

## `testcase.xml`

Test Specification 데이터를 저장합니다.

```xml
<Test>
    <Data id="0">
        <Test_name>Test 1</Test_name>
        <Min>0</Min>
        <Max>100</Max>
        <Voltage>5</Voltage>
        <Measured_value></Measured_value>
        <Result></Result>
    </Data>
</Test>
```

여러 검사 항목을 저장할 경우:

```xml
<Test>
    <Data id="0">
        ...
    </Data>

    <Data id="1">
        ...
    </Data>

    <Data id="2">
        ...
    </Data>
</Test>
```

---

# ▶️ 실행 방법

## 1. 프로젝트 Clone

GitHub에서 프로젝트를 Clone합니다.

```bash
git clone <repository-url>
```

## 2. Visual Studio에서 Solution 열기

다음 파일을 Visual Studio 2012에서 엽니다.

```text
Change_Test_Specification.sln
```

## 3. 빌드

Visual Studio에서 프로젝트를 Build합니다.

```text
Build → Build Solution
```

## 4. 실행

Debug 또는 Release 모드에서 프로그램을 실행합니다.

---

# ⚠️ 주의사항

### XML 파일 경로

현재 프로젝트는 실행 경로를 기준으로 다음 위치를 사용합니다.

```text
..\..\res\xml\testcase.xml
..\..\res\xml\path.xml
```

따라서 프로젝트 구조가 변경되거나 실행 파일의 위치가 변경되면 XML 파일 경로가 정상적으로 동작하지 않을 수 있습니다.

### XML 파일 삭제

Editor에서 XML 파일 삭제 기능을 사용할 경우 선택한 실제 파일이 삭제됩니다.

삭제 전에 파일을 다시 확인하는 것이 좋습니다.

### 데이터 저장

저장 과정에서 기존 `/Test` 하위 데이터가 삭제된 후 `DataGridView`의 내용을 기준으로 다시 생성됩니다.

따라서 저장 전에 입력 내용을 확인해야 합니다.

---

# 📌 현재 구현 상태

| 기능                    |   상태  |
| --------------------- | :---: |
| XML 파일 읽기             |   ✅   |
| XML 파일 생성             |   ✅   |
| XML 파일 삭제             |   ✅   |
| XML 파일 Load           |   ✅   |
| XML 파일 저장             |   ✅   |
| Test Specification 조회 |   ✅   |
| Test Specification 수정 |   ✅   |
| 행 추가                  |   ✅   |
| 행 삭제                  |   ✅   |
| Min/Max/Voltage 숫자 검증 |   ✅   |
| Min < Max 검증          |   ✅   |
| XML 파일명 변경            | ⏳ 미구현 |
| Measured Value 자동 측정  | ⏳ 미구현 |
| Result 자동 판정          | ⏳ 미구현 |

---

# 🚀 향후 개선 방향

* XML 파일명 변경 기능 구현
* XML 데이터에 대한 더욱 세분화된 예외 처리
* 파일 경로를 상대 경로가 아닌 설정 기반으로 관리
* `TestCaseModel`의 데이터 관리 구조 개선
* `Measured_value` 자동 입력 기능 추가
* `Min / Max` 기준에 따른 `Result` 자동 판정 기능 추가
* 사용자 입력에 대한 DataGridView 단계의 실시간 검증
* XML 파일 백업 및 복구 기능 추가
* MVVM 또는 별도의 계층 구조를 적용하여 UI와 데이터 처리 로직 분리

---

# 👨‍💻 Project

**Change Test Specification**

C# / Windows Forms 기반의 Test Specification XML 관리 프로그램

> 본 프로젝트는 검사 장비에서 사용되는 Test Specification 데이터를 효율적으로 관리하기 위한 목적으로 개발되었습니다.
