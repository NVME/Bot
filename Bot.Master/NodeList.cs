using System;
using System.Collections.Generic;
using Bot.COMM;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Bot.Master
{
    public static class NodeList
    {
        public static readonly List<NodeDto> list = new List<NodeDto>();

        public static List<NodeDto> GetList(string region = "apj")
        {


            var english = new Language
            {
                EnglishName = "English",
                LanguageCode = "en-us",
                LanguageId = 1,
                LocalName = "English",
                keywords = new List<string> { "en", "english", "EN", "English", "ENGLISH", "en-us" }
            };
            var cantonese = new Language
            {
                EnglishName = "Cantonese",
                LanguageCode = "cantonese",
                LanguageId = 5,
                LocalName = "Yue Yu",
                keywords = new List<string> { "yue", "cantonese" }
            };
            var mandarin = new Language
            {
                EnglishName = "Mandarin",
                LanguageCode = "mandarin",
                LanguageId = 3,
                LocalName = "Pu Tong Hua",
                keywords = new List<string> { "han" }
            };

            var japanese = new Language
            {
                EnglishName = "Japanese",
                LanguageCode = "japanese",
                LanguageId = 6,
                LocalName = "Ri Yu",
                keywords = new List<string> { "ri", "jpan" }
            };

            var korean = new Language
            {
                EnglishName = "Korean",
                LanguageCode = "korean",
                LanguageId = 6,
                LocalName = "Chao Xian Yu",
                keywords = new List<string> { "korean", "k" }
            };

            var welcome = new NodeDto
            {
                Id = 10001,
                ParentId = 10001,
                TypeId = 1,// Language node
                TypeName = "LanguageNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "Welcome to the Service Desk!" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "歡迎來到服務台！" },
                           new LocalPhrase {LanguageCode="mandarin",Text="欢迎来到服务台！"},
                           new LocalPhrase {LanguageCode="japanese", Text="Service Deskへようこそ！"},
                           new LocalPhrase {LanguageCode="korean", Text="Service Desk에 오신 것을 환영합니다!"}
                    }
                },
                HeaderTextFormat = "font-weight: bold;",
                DisclaimerText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "This converstaion may be recorded for quality assurance purposes." },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "為了質量保證的目的，這個對話可能被記錄下來。" },
                           new LocalPhrase {LanguageCode="mandarin",Text="为了保证质量，可能会记录此对话！"},
                           new LocalPhrase {LanguageCode="japanese", Text="「この会話は、品質保証の目的で記録されるかもしれません。"},
                           new LocalPhrase {LanguageCode="korean", Text="이 대화는 품질 보증 목적으로 기록 될 수 있습니다."}
                    }
                },
                DisclaimerTextFormat = "font-style: italic;",
                FooterText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "To speak with an agent at any time type \"agent\"" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "隨時與代理商聯繫打“代理商”" },
                           new LocalPhrase {LanguageCode="mandarin",Text="随时与代理商联系打“代理商”"},
                           new LocalPhrase {LanguageCode="japanese", Text="いつでもエージェントと話すには、エージェント とタイプします。"},
                           new LocalPhrase {LanguageCode="korean", Text="언제든지 상담원과 통화하려면 “상담원” 을 입력하십시오."}
                    }
                },

                FooterTextFormat = "",
                Keywords = new List<GlobalPhrase>(),
                OptionText = new GlobalPhrase(),
                OptionTextFormat = "",
                LanguageOptions = new List<LanguageOption> {
                     new LanguageOption {Language=english, NodeId=11001 },
                     new LanguageOption {Language=cantonese,NodeId=11001 },
                     new LanguageOption {Language=mandarin,NodeId=11001 },
                     new LanguageOption {Language=japanese,NodeId=11001 },
                     new LanguageOption {Language=korean, NodeId=11001 }
                    },
                LanguageAltText = new List<string> { "en", "can", "mad", "jpn", "kor" },
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = true,
                DisableGoBackOption = false,
                DisplayChosenText = false,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var menu = new NodeDto
            {
                Id = 11001,
                ParentId = 11001, // top node , it is its own parent
                TypeId = 2,// Menu node
                TypeName = "MenuNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "Please select the category that best describes your issue by typing a number:" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "請通過輸入一個數字來選擇最能描述您問題的類別：" },
                           new LocalPhrase {LanguageCode="mandarin",Text="请通过输入一个数字来选择最能描述您问题的类别："},
                           new LocalPhrase {LanguageCode="japanese", Text="番号を入力して、問題を最もよく表すカテゴリを選択してください："},
                           new LocalPhrase {LanguageCode="korean", Text="번호를 입력하여 문제를 가장 잘 설명하는 카테고리를 선택하십시오."}
                    }
                },
                HeaderTextFormat = "font-weight: bold;",
                DisclaimerText = new GlobalPhrase(),
                DisclaimerTextFormat = "",
                FooterText = new GlobalPhrase(),
                FooterTextFormat = "",
                Keywords = new List<GlobalPhrase>(),
                OptionText = new GlobalPhrase(),
                OptionTextFormat = "",
                LanguageAltText = new List<string>(),
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = false,
                DisplayChosenText = false,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = true,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var passwordReset = new NodeDto
            {
                Id = 11101,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "Due to security requirements, password resets are not allowed throught chat.For JCI Global ID password resets, please look first at the self-service guid available at the following link:Password Reset Tool Guids, If you need further assistance,please contact the service desk via phone." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "由於安全要求，不允許通過聊天進行密碼重置。對於JCI Global ID密碼重置，請首先查看以下鏈接提供的自助GUID：Password Reset Tool Guids，如果您需要進一步幫助，請聯繫服務 桌子通過電話。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="由于安全要求，不允许通过聊天进行密码重置。对于JCI Global ID密码重置，请首先查看以下链接提供的自助GUID：Password Reset Tool Guids，如果您需要进一步的帮助，请联系服务 桌子通过电话。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="セキュリティ要件のため、パスワードリセットはチャットでは許可されません。JCIグローバルIDパスワードのリセットについては、まず以下のリンクにあるセルフサービスガイドをご覧ください：パスワードリセットツールガイド、さらに支援が必要な場合は、 電話での机。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="보안 요구 사항으로 인해 채팅을 통한 비밀번호 재설정이 허용되지 않습니다. JCI 글로벌 ID 비밀번호 재설정의 경우 다음 링크에서 제공되는 셀프 서비스 안내서를 먼저 확인하십시오. 비밀번호 재설정 도구 안내, 추가 도움이 필요하면 서비스에 문의하십시오. 전화를 통한 책상."}
                    }
                },

                HeaderTextFormat = "",
                Keywords = new List<GlobalPhrase>{
                        new GlobalPhrase { }
                     },
                //"p", "pass", "P", "PASS", "RESET", "reset"
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Password Reset" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "重設密碼" },
                           new LocalPhrase {LanguageCode="mandarin",Text="重设密码"},
                           new LocalPhrase {LanguageCode="japanese", Text="パスワードのリセット"},
                           new LocalPhrase {LanguageCode="korean", Text="비밀번호 초기화"}
                    }
                },
                OptionTextFormat = "",
                DisclaimerText = null,
            DisclaimerTextFormat = "",
            FooterText = null,
            FooterTextFormat = "",
            LanguageOptions = null,
            LanguageAltText = null,
            Queue = null,
            QueueName = null,
            UseEnglishLanguageName = false,
            DisableGoBackOption = true,
            DisplayChosenText = true,
            DisplayHoursOfOperation = false,
            DisplaySelectionText = false,
            ShowConfirmation = false,
            HideMenu = false,
            HideMenuNumbers = false,
            AdditionalOptions = "",
            CweCommand = ""
        };

            var software = new NodeDto
            {
                Id = 11102,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText =
                new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "For all new software installation request, please use the Software Catalog (https://ordermypc.jci.com/softwareorder/gettingstarted) to submit your request.If this does not resolve your query, please go back to the main mene and use the option: All Other Support." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "對於所有新的軟件安裝請求，請使用軟件目錄（https://ordermypc.jci.com/softwareorder/gettingstarted）來提交您的請求。如果這不能解決您的查詢，請回到主要的mene並使用 選項：所有其他支持。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="对于所有新的软件安装请求，请使用软件目录（https://ordermypc.jci.com/softwareorder/gettingstarted）来提交您的请求。如果这不能解决您的查询，请回到主要的mene并使用 选项：所有其他支持。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="すべての新しいソフトウェアのインストール要求については、ソフトウェアカタログ（https://ordermypc.jci.com/softwareorder/gettingstarted）を使用してリクエストを送信してください。これでクエリが解決しない場合は、メインメーンに戻り、 オプション：その他すべてのサポート。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="새로운 소프트웨어 설치 요청에 대해서는 소프트웨어 카탈로그 (https://ordermypc.jci.com/softwareorder/gettingstarted)를 사용하여 요청을 제출하십시오. 그래도 문제가 해결되지 않으면 주 메뉴로 돌아가서 옵션 : 기타 모든 지원."}
                    }
                },

                HeaderTextFormat = "",
                // Keywords = new List<string>() { "s", "soft", "S", "SOFT", "INSTALL", "install" },
                Keywords = new List<GlobalPhrase>{
                        new GlobalPhrase { }
                     },
                //"p", "pass", "P", "PASS", "RESET", "reset"
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Software installation" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "軟件安裝" },
                           new LocalPhrase {LanguageCode="mandarin",Text="软件安装"},
                           new LocalPhrase {LanguageCode="japanese", Text="ソフトウェアのインストール"},
                           new LocalPhrase {LanguageCode="korean", Text="소프트웨어 설치"}
                    }
                },

                OptionTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = true,
                DisplayChosenText = true,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""

            };

            var status = new NodeDto
            {
                Id = 11103,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "Before contacting the Service Desk, please check your ticket status on the IT Service Catalog at this link :<link></link>.If this doese not resolve yoru query, please go back to main menu and use the option: All Other Support." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "在聯繫服務台之前，請檢查您在IT服務目錄上的票務狀態，鏈接如下：<link> </ link>。如果這個問題沒有解決，請返回主菜單並使用選項：All Other Support。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="在联系服务台之前，请在以下链接上检查IT服务目录中的票据状态：<link> </ link>。如果这个问题没有解决，请返回主菜单并使用选项：All Other Support。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="サービスデスクにご連絡いただく前に、ITサービスカタログのチケットステータスを以下のリンクからご確認ください：<link> </ link>これでyoruの問い合わせが解決しない場合は、メインメニューに戻り、 。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="서비스 데스크에 연락하기 전에 IT 서비스 카탈로그의 <link> </ link> 링크에서 티켓 상태를 확인하십시오. 이렇게하면 yoru 쿼리가 해결되지 않고 기본 메뉴로 돌아가서 다음 옵션을 사용하십시오. ."}
                    }
                },

                HeaderTextFormat = "",
                //Keywords = new List<string>() { "check", "status", "StATUS", "CHECK", "C", "c" },
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Status Check on Existing Ticket" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "現有票據的狀態檢查" },
                           new LocalPhrase {LanguageCode="mandarin",Text="现有票据的状态检查"},
                           new LocalPhrase {LanguageCode="japanese", Text="既存チケットのステータスチェック"},
                           new LocalPhrase {LanguageCode="korean", Text="기존 티켓의 상태 확인"}
                    }
                },

                OptionTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = true,
                DisplayChosenText = true,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var outlook = new NodeDto
            {
                Id = 11104,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "For your awareness, there is infomation for the most common Outlook/Mobility issues and requests on the IT Service Catalog in the Communication Tab, if this does not resolve your issue, please press 1 beloow to communicate with an agent." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "為了您的了解，有關最常見的Outlook / Mobility問題的信息以及通信選項卡中IT服務目錄上的請求，如果這不能解決您的問題，請按1以與代理通信。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="为了您的了解，有关最常见的Outlook / Mobility问题的信息以及“通信”选项卡中IT服务目录上的请求，如果这不能解决您的问题，请按1以与代理通信。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="あなたの意識のために、最も一般的なOutlook / Mobilityの問題とITサービスカタログの[通信]タブのリクエストに関する情報がありますが、問題が解決しない場合は、1を押してエージェントと通信してください。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="귀하의 인식을 위해 가장 일반적인 Outlook / 모바일 문제 및 통신 탭의 IT 서비스 카탈로그 요청에 대한 정보가 있습니다. 문제가 해결되지 않으면 1을 눌러 에이전트와 통신하십시오."}
                    }
                },

                HeaderTextFormat = "",
                //Keywords = new List<string>() { "o", "outlook", "O", "OUTLOOK" },
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Support for Outlook and Mobility  " },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "支持Outlook和移動" },
                           new LocalPhrase {LanguageCode="mandarin",Text="支持Outlook和移动"},
                           new LocalPhrase {LanguageCode="japanese", Text="Outlookとモビリティのサポート"},
                           new LocalPhrase {LanguageCode="korean", Text="Outlook 및 모바일 지원"}
                    }
                },

                OptionTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = true,
                DisplayChosenText = true,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var sap = new NodeDto
            {
                Id = 11105,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "SAP Support is not offered via chat.Please call the Service Desk Number for your courntry and select option 2-SAP Support to connect to the SAP Service Desk." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "SAP支持不是通過聊天提供的。請致電您的服務台的服務台號碼，並選擇選項2-SAP支持以連接到SAP服務台。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="SAP支持不是通过聊天提供的。请致电您的服务台的服务台号码，并选择选项2-SAP支持以连接到SAP服务台。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="SAPサポートはチャットでは提供されていません。ご要望に応じてサービスデスク番号に電話し、オプション2-SAPサポートを選択してSAPサービスデスクに接続してください。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="SAP 지원은 채팅을 통해 제공되지 않습니다. SAP 서비스 데스크에 연결하려면 상담원의 서비스 데스크 번호로 전화하고 2-SAP 지원 옵션을 선택하십시오."}
                    }
                },
                HeaderTextFormat = "",
                // Keywords = new List<string>() { "sap", "SAP" },               
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "SAP Support" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "SAP支持" },
                           new LocalPhrase {LanguageCode="mandarin",Text="SAP支持"},
                           new LocalPhrase {LanguageCode="japanese", Text="SAPサポート"},
                           new LocalPhrase {LanguageCode="korean", Text="SAP 지원"}
                    }
                },
                OptionTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = true,
                DisplayChosenText = true,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var ssna = new NodeDto
            {
                Id = 11106,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "This includes applications like AIM Tools, NXGen, yorkworks. BE SSNA support is not offered through Chat. For contact details, please see the Service Desk Support on the IT Service Catalog." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "這包括AIM Tools，NXGen，yorkworks等應用程序。 BE SSNA支持不是通過聊天提供的。 有關詳細聯繫信息，請參閱IT服務目錄上的服務台支持。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="这包括AIM Tools，NXGen，yorkworks等应用程序。 BE SSNA支持不是通过聊天提供的。 有关详细联系信息，请参阅IT服务目录上的服务台支持。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="これには、AIMツール、NXGen、yorkworksなどのアプリケーションが含まれます。 BE SSNAサポートはチャットを通じて提供されていません。 連絡先の詳細については、ITサービスカタログのService Deskサポートを参照してください。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="여기에는 AIM Tools, NXGen, yorkworks와 같은 응용 프로그램이 포함됩니다. BE SSNA 지원은 채팅을 통해 제공되지 않습니다. 연락처 정보는 IT 서비스 카탈로그의 서비스 데스크 지원을 참조하십시오."}
                    }
                },

                HeaderTextFormat = "",
                // Keywords = new List<string>() { "ssna", "SSNA" },
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "AMS Only-BE SSNA Support" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "AMS Only-BE SSNA支持" },
                           new LocalPhrase {LanguageCode="mandarin",Text="AMS Only-BE SSNA支持"},
                           new LocalPhrase {LanguageCode="japanese", Text="AMS Only-BE SSNAサポート"},
                           new LocalPhrase {LanguageCode="korean", Text="AMS Only-BE SSNA 지원"}
                    }
                },
                OptionTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = true,
                DisplayChosenText = true,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var other = new NodeDto
            {
                Id = 11107,
                ParentId = 11001,
                TypeId = 3,// Informational node
                TypeName = "InformationalNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",
                              Text = "Please check the IT Service Catalog for a solution to your request/issue. If you can't find a solution,please press 1 below to commnunicate with an agent." },
                           new LocalPhrase {  LanguageCode="cantonese",
                               Text = "請查看IT服務目錄以獲取您的請求/問題的解決方案。 如果找不到解決方案，請按下面的1與代理商交流。" },
                           new LocalPhrase {LanguageCode="mandarin",
                               Text ="请查看IT服务目录以获取您的请求/问题的解决方案。 如果找不到解决方案，请按下面的1与代理商交流。"},
                           new LocalPhrase {LanguageCode="japanese",
                               Text ="あなたの要求/問題の解決方法については、ITサービスカタログをご確認ください。 解決策が見つからない場合は、下記の1を押してエージェントと通信してください。"},
                           new LocalPhrase {LanguageCode="korean",
                               Text ="귀하의 요청 / 문제에 대한 해결책을 IT 서비스 카탈로그에서 확인하십시오. 해결책을 찾을 수없는 경우 아래 1을 눌러 상담원과 연락하십시오."}
                    }
                },
                HeaderTextFormat = "",
                //Keywords = new List<string>() { "other", "OTHER" },
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "All Other" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "所有其他" },
                           new LocalPhrase {LanguageCode="mandarin",Text="所有其他"},
                           new LocalPhrase {LanguageCode="japanese", Text="他のすべて"},
                           new LocalPhrase {LanguageCode="korean", Text="그 외 모든 것들"}
                    }
                },
                OptionTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = null,
                QueueName = null,
                UseEnglishLanguageName = false,
                DisableGoBackOption = true,
                DisplayChosenText = true,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = false,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };


            var handoffother = new NodeDto
            {
                Id = 11111,
                ParentId = 11107,
                TypeId = 4,// Hand off node
                TypeName = "HandOffNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Please wait for connecting an agent." },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "請等待連接代理。" },
                           new LocalPhrase {LanguageCode="mandarin",Text="请等待连接代理。"},
                           new LocalPhrase {LanguageCode="japanese", Text="エージェントの接続を待ってください。"},
                           new LocalPhrase {LanguageCode="korean", Text="상담원 연결을 기다려주십시오.   "}
                    }
                },

                HeaderTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                Keywords = null,
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Chat with Agent" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "與代理聊天" },
                           new LocalPhrase {LanguageCode="mandarin",Text="与代理聊天"},
                           new LocalPhrase {LanguageCode="japanese", Text="エージェントとチャット"},
                           new LocalPhrase {LanguageCode="korean", Text="상담원과 채팅"}
                    }
                },
                OptionTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = new QueueDto
                {
                    Id = 101,
                    Name = "Service Desk Queue 1",
                    SupportedLanguages = new List<string> { "en-us" },
                    CustomerId = "003",
                    SIP = "test@hpe.com",
                    BackupSIP = "test@dxc.com",
                    HoursOfOperation = new HoursOfOperation
                    {
                        TimeZone = "UTC",
                        WorkDays = new List<WorkDay>
                                {// seven days
                                    new WorkDay { Day=DayOfWeek.Sunday, Type=Choice.Closed },
                                    new WorkDay {Day=DayOfWeek.Saturday, Type=Choice.Custom ,
                                                WorkShifts = new List<WorkShift> { new WorkShift (6,11),new WorkShift (13,20) } },
                                     new WorkDay {Day=DayOfWeek.Monday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Tuesday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Wednesday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Thursday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Friday, Type=Choice.All24Hours }
                                 }

                    }


                },
                QueueName = new GlobalQueueName
                {
                    QueueNames = new List<LocalQueueName> {
                    new LocalQueueName { LanguageCode="en-us", QueueName="Service Desk Queue 1" }
                }
                },
                UseEnglishLanguageName = false,
                DisableGoBackOption = false,
                DisplayChosenText = false,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = true,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };

            var handoffoutlook = new NodeDto
            {
                Id = 11111,
                ParentId = 11104,
                TypeId = 4,// Hand off node
                TypeName = "HandOffNode",
                HeaderText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Please wait for connecting an agent." },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "請等待連接代理。" },
                           new LocalPhrase {LanguageCode="mandarin",Text="请等待连接代理。"},
                           new LocalPhrase {LanguageCode="japanese", Text="エージェントの接続を待ってください。"},
                           new LocalPhrase {LanguageCode="korean", Text="상담원 연결을 기다려주십시오.   "}
                    }
                },
                HeaderTextFormat = "",
                DisclaimerText = null,
                DisclaimerTextFormat = "",
                FooterText = null,
                FooterTextFormat = "",
                Keywords = null,
                OptionText = new GlobalPhrase
                {
                    Id = "",
                    Phrases = new List<LocalPhrase> {
                          new LocalPhrase {  LanguageCode="en-us",Text = "Chat with Agent" },
                           new LocalPhrase {  LanguageCode="cantonese",Text = "與代理聊天" },
                           new LocalPhrase {LanguageCode="mandarin",Text="与代理聊天"},
                           new LocalPhrase {LanguageCode="japanese", Text="エージェントとチャット"},
                           new LocalPhrase {LanguageCode="korean", Text="상담원과 채팅"}
                    }
                },
                OptionTextFormat = "",
                LanguageOptions = null,
                LanguageAltText = null,
                Queue = new QueueDto
                {
                    Id = 102,
                    Name = "Service Desk Queue 2",
                    SupportedLanguages = new List<string> { "en-us" },
                    CustomerId = "003",
                    SIP = "test@hpe.com",
                    BackupSIP = "test@dxc.com",
                    HoursOfOperation = new HoursOfOperation
                    {
                        TimeZone = "UTC",
                        WorkDays = new List<WorkDay>
                                {// seven days
                                   new WorkDay { Day=DayOfWeek.Sunday, Type=Choice.Closed },
                                    new WorkDay {Day=DayOfWeek.Saturday, Type=Choice.Custom ,
                                                WorkShifts = new List<WorkShift> { new WorkShift (6,11),new WorkShift (13,20) } },
                                     new WorkDay {Day=DayOfWeek.Monday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Tuesday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Wednesday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Thursday, Type=Choice.All24Hours }  ,
                                     new WorkDay {Day=DayOfWeek.Friday, Type=Choice.All24Hours }
                                 }

                    }


                },
                QueueName = new GlobalQueueName
                {
                    QueueNames = new List<LocalQueueName> {
                    new LocalQueueName { LanguageCode="en-us", QueueName="Service Desk Queue 2" }
                }
                },
                UseEnglishLanguageName = false,
                DisableGoBackOption = false,
                DisplayChosenText = false,
                DisplayHoursOfOperation = false,
                DisplaySelectionText = false,
                ShowConfirmation = true,
                HideMenu = false,
                HideMenuNumbers = false,
                AdditionalOptions = "",
                CweCommand = ""
            };
            list.AddMany<NodeDto>(welcome, menu, passwordReset, software, status, outlook, sap, ssna, other, handoffother, handoffoutlook);
            return list;
        }

        public static string ToJson()
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return jsonString;
        }


    }


    

    

}
