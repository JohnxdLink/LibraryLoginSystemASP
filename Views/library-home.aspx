<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="library-home.aspx.cs" Inherits="Library_Login_System.Views.library_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--
        Project: Library Login System
        Developer: Castro John Christian
        Message: StoryVerse: "Where Words Come Alive"
        Date Created: 05/10-16/2023
        -->
    <link rel="stylesheet" type="text/css" href="../Style/library-home.css" />
    <title>Library | Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="timedate">
                        <div class="digital-clock">
                            <asp:Label ID="Lbl_current_time" runat="server" Text="00:00:00"></asp:Label>
                        </div>

                        <div class="date">
                            <asp:Label ID="Lbl_current_date" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="systemindicator">
                        <asp:Label ID="Lbl_system" runat="server" Text=""></asp:Label>
                    </div>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>

            </asp:UpdatePanel>

            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>

            <div class="logo-image">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/library.png" Height="250" Width="250" />
            </div>

            <div class="logo-name">
                <asp:Label ID="Lbl_Logo_name" runat="server" Text="StoryVerse"></asp:Label>
            </div>

            <div class="tagline">
                <asp:Label ID="Lbl_tagline" runat="server" Text="WHERE WORDS COME ALIVE"></asp:Label>
            </div>

            <div class="logandregister">
                <asp:Button ID="Btn_Login" runat="server" Text="LOGIN" OnClick="Btn_Login_Click" />
                <asp:Button ID="Btn_Register" runat="server" Text="REGISTER" OnClick="Btn_Register_Click" />
            </div>
        </div>
    </form>
</body>
</html>
