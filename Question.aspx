<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="StudyWords.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .boxPrincipal {
            border: 0px solid;
            padding: 15px;
            background: #fff;
            border-collapse: separate;
            width: 400px;
            height: 150px;
        }

        .ckOption {
            cursor: pointer;
        }
        .boxCheck {
            float:right;
            width: 50%;
        }

        .button {
            width: 100px;
            text-align: center;
        }

        .btNext {
            float: right;
        }

        .btPrevious {
            float: left;
        }

        body {
            background: #f1f4f9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btLoadQuestion" runat="server" Text="Load Question" OnClick="OnClick_btLoadQuestion" />
        </div>
        <div class="boxPrincipal">

            <fieldset id="fdsQuestion">
                <legend>Question</legend>
                <div id="divQuestion" runat="server" class="BoxQuestion">
                    <asp:Label ID="lbQuestion" runat="server" ></asp:Label>
                </div>
            </fieldset>

            <fieldset id="fdsOption">
                <legend>Option</legend>
                <div id="divOption" runat="server" class="BoxOption">
                    <div class="boxCheck"> <asp:RadioButton ID="rb1Text" runat="server" Text="be" ToolTip="be" GroupName="Group" CssClass="ckOption"  /></div>
                    <div class="boxCheck"> <asp:RadioButton ID="rb2Text" runat="server" Text="we/was" ToolTip="we/was" GroupName="Group" CssClass="ckOption" /></div>
                    <div class="boxCheck"> <asp:RadioButton ID="rb3Text" runat="server" Text="been" ToolTip="been" GroupName="Group" CssClass="ckOption" /></div>
                    <div class="boxCheck"> <asp:RadioButton ID="rb4Text" runat="server" Text="was" ToolTip="was" GroupName="Group" CssClass="ckOption" /></div>
                </div>
            </fieldset>

            <div class="btPrevious">
                <asp:Button ID="btPrevious" runat="server" Text="Previous" CssClass="button" OnClick="btPrevious_OnClick" />
            </div>
            <div class="btNext">
                <asp:Button ID="btNext" runat="server" Text="Next" CssClass="button" OnClick="btNext_OnClick" />
            </div>
        </div>
    </form>
</body>
</html>
