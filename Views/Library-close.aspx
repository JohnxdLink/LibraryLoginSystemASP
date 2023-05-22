<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="library-close.aspx.cs" Inherits="Library_Login_System.Views.Library_close" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../Style/library-close.css" />
    <title>Library | Close</title>
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
                <asp:Label ID="Lbl_Logo_name" runat="server" Text="StoryVerse library is unavailable."></asp:Label>
            </div>

            <div class="tagline">
                <asp:Label ID="Lbl_tagline" runat="server" Text="TIME OPEN: 7:00AM - 5:00PM"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
