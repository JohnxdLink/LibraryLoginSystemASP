<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="library-admin.aspx.cs" Inherits="Library_Login_System.Views.library_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Style/library-admin.css" />
    <title>Library | Admin</title>
</head>
<body>
    <!--
        Project: Library Login System
        Developer: Castro John Christian
        Message: StoryVerse: "Where Words Come Alive"
        Date Created: 05/22/2023
        -->

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="whole-container">
            <!--Aside Container Left-->
            <aside class="aside-left-20">
                <!--Logo-->
                <div class="library-logo">
                    <asp:ImageButton ID="Img_btn_to_home" runat="server" ImageUrl="~/Images/Icons/library.png" Height="170px" Width="170px" />
                </div>

                <!--Buttons-->
                <div class="left-buttons">
                    <asp:Button ID="btn_home" runat="server" Text="HOME" CssClass="left-btn-design" />
                    <asp:Button ID="btn_student" runat="server" Text="STUDENTS" CssClass="left-btn-design" />
                    <asp:Button ID="btn_timelog" runat="server" Text="TIMELOG" CssClass="left-btn-design" />
                    <asp:Button ID="btn_graph" runat="server" Text="GRAPH" CssClass="left-btn-design" />
                    <asp:Button ID="btn_logout" runat="server" Text="LOGOUT" CssClass="left-btn-design" Style="margin-top: 122%;" />
                </div>
            </aside>

            <!--Main Container-->
            <main class="main-50">

                <!--Time & Date Container-->
                <div class="timedate-container">
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                </div>

                <div class="nav-status-con">
                    <div class="admin-library_status">
                        <asp:Image ID="img_admin_status_library" runat="server" ImageUrl="~/Images/Icons/adming-status-library.PNG" Height="30px" Width="30px" />
                        <asp:Label ID="Label1" runat="server" Text="LIBRARY: " CssClass="status_design"></asp:Label>
                        <asp:Label ID="lbl_admin_status_library" runat="server" Text="UNAVAILABLE" Style="margin-left: 15px; color: #ff0000;" CssClass="status_design"></asp:Label>
                    </div>

                    <div class="admin-login_status">
                        <asp:Image ID="img_admin_status_login" runat="server" ImageUrl="~/Images/Icons/admin-status-login.PNG" Height="30px" Width="30px" />
                        <asp:Label ID="Label2" runat="server" Text="LOGIN: " CssClass="status_design"></asp:Label>
                        <asp:Label ID="lbl_admin_status_login" runat="server" Text="ONLINE" Style="margin-left: 15px; color: #00ff00;" CssClass="status_design"></asp:Label>
                    </div>

                    <div class="admin-register-status">
                        <asp:Image ID="img_admin_status_register" runat="server" Height="30px" ImageUrl="~/Images/Icons/admin-status-register.PNG" Width="30px" />
                        <asp:Label ID="Label3" runat="server" Text="REGISTER: " CssClass="status_design"></asp:Label>
                        <asp:Label ID="lbl_admin_status_register" runat="server" Text="ONLINE" Style="margin-left: 15px; color: #00ff00;" CssClass="status_design"></asp:Label>
                    </div>
                </div>

            </main>

            <!--Aside Container Right-->
            <aside class="aside-right-30">
                Right Content
            </aside>
        </div>
    </form>
</body>
</html>
