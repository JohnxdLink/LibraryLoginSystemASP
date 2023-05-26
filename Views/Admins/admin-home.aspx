<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin-home.aspx.cs" Inherits="Library_Login_System.Views.Admins.admin_home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../../Style/Admin-Styles/admin-home.css" />
    <title>Admin | Home</title>
</head>
<body>
    <form id="form1" runat="server">

        <!--Whole Container-->
        <div class="whole-container">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <!--Aside Left-->
            <aside class="aside-left-15">

                <!--Logo-->
                <div class="logo-img">
                    <asp:ImageButton ID="img_btn_logo" runat="server" ImageUrl="~/Images/Icons/library.png" Height="150" Width="150" />
                </div>


                <!--Buttons-->
                <div class="button-container">
                    <div class="button-group">
                        <asp:Button ID="btn_home" runat="server" Text="HOME" CssClass="button-design" OnClick="btn_home_Click" />
                        <asp:Button ID="btn_register" runat="server" Text="REGISTERED" CssClass="button-design" OnClick="btn_register_Click" />
                        <asp:Button ID="btn_timelog" runat="server" Text="TIMELOG" CssClass="button-design" OnClick="btn_timelog_Click" />
                        <asp:Button ID="btn_graph" runat="server" Text="GRAPH" CssClass="button-design" OnClick="btn_graph_Click" />
                    </div>


                    <!--Separated Button For Logout-->
                    <div class="button-group">
                        <asp:Button ID="btn_logout" runat="server" Text="LOGOUT" CssClass="button-design" OnClick="btn_logout_Click" />
                    </div>
                </div>
            </aside>


            <!--Main Content 60%-->
            <main class="main-60">

                <!--Inside Main-->
                <div class="inside-main-layout">

                    <!--Inside Header-->
                    <header class="inside-header">

                        <!--Library Status: Available/Unvailable-->
                        <div class="library-status" style="margin-top: 10px; margin-left: 10px;">
                            <asp:Image ID="img_icon_library" runat="server" ImageUrl="~/Images/Icons/library-status.PNG" Height="30" Width="30" />
                            <asp:Label ID="Lbl_library_status" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                        </div>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <!--Time Zone-->
                                <div class="time-date">

                                    <!--Digital Clock-->
                                    <div class="digital-clock">
                                        <asp:Label ID="Lbl_current_time" runat="server" Text=""></asp:Label><br />
                                    </div>

                                    <!--Date-->
                                    <div class="date">
                                        <asp:Label ID="Lbl_current_date" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </ContentTemplate>

                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>

                    </header>

                    <!--Inside Aside Left-->
                    <aside class="inside-aside-left-50">

                        <!--Search Student-->
                        <div class="srch-student-con" style="margin-left: 10px;">

                            <!--Textbox Search & Browser Icon-->
                            <div class="srch-container" style="margin-bottom: 10px;">
                                <asp:TextBox ID="Txb_search_id" runat="server" Style="margin-right: 10px;" ToolTip="Search ID" placeholder="Search ID"></asp:TextBox>
                                <asp:ImageButton ID="Img_browse_id" runat="server" ImageUrl="~/Images/Icons/admin-browse.PNG" Height="40" Width="40" />
                            </div>

                            <!--Display The Search ID-->
                            <div class="dsply-srch-container">

                                <!--Student Picture Display-->
                                <div class="student-pic" style="margin-right: 10px; float: left;">
                                    <asp:Image ID="Img_student" runat="server" Height="170" Width="170" />
                                </div>

                                <!--Display Info Student-->
                                <div class="student-info-container">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/admin-std-id.PNG" Height="30" Width="30" />
                                    <asp:Label ID="Lbl_std_id" runat="server" Text="777000" CssClass="std-dsply-design"></asp:Label>
                                    <br />
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/admin-std-name.PNG" Height="30" Width="30" />
                                    <asp:Label ID="Lbl_std_name" runat="server" Text="Castro John Christian" CssClass="std-dsply-design"></asp:Label>
                                    <br />
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/admin-std-course.PNG" Height="30" Width="30" />
                                    <asp:Label ID="Lbl_std_course" runat="server" Text="BSIT" CssClass="std-dsply-design"></asp:Label>
                                    <br />
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/admin-std-year.PNG" Height="30" Width="30" />
                                    <asp:Label ID="Lbl_std_year" runat="server" Text="1st Year" CssClass="std-dsply-design"></asp:Label>
                                    <br />
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Icons/admin-std-major.PNG" Height="30" Width="30" />
                                    <asp:Label ID="Lbl_std_major" runat="server" Text="Info-Tech" CssClass="std-dsply-design"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </aside>

                    <!--Inside Aside Right-->
                    <aside class="inside-aside-right-50">
                        <div class="std-timelog">
                            <div class="std-timelog-display">
                                <asp:Image ID="Image6" runat="server" Height="70" Width="70" ImageUrl="~/Images/Icons/timelog.png" />
                                <asp:Label ID="Lbl_std_timelog" runat="server" Text="00" Style="font-family: 'Bebas Neue'; font-size: 50px;"></asp:Label>
                            </div>

                            <div class="std-timelog-data">
                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                            </div>
                        </div>
                    </aside>
                </div>

                <!--Inside Footer-->
                <footer class="inside-footer">

                    <!--Inside Footer Left-->
                    <aside class="inside-footer-left-50">

                        <div class="text-register">
                            <asp:Label ID="Label1" runat="server" Text="REGISTERED STUDENT" Style="font-family: 'Bebas Neue'; font-size: 25px; margin-left: 10px;"></asp:Label>
                        </div>

                        <div class="registered-design">
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Icons/admin-registered.png" />
                            <asp:Label ID="Lbl_num_registered" runat="server" Text="00" Style="font-family: 'Bebas Neue'; font-size: 50px;"></asp:Label>
                        </div>

                        <div class="register-notify" style="margin-left: 10px;">
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/Icons/admin-notify.PNG" Height="20" Width="20" />
                            <asp:Label ID="Lbl_std_add_notify" runat="server" Text="NO STUDENT ADDED " Style="font-family: 'Bebas Neue'; font-size: 15px;"></asp:Label>
                        </div>
                    </aside>


                    <!--Inside Footer Right-->
                    <aside class="inside-footer-right-50">

                        <div class="text-register">
                            <asp:Label ID="Label2" runat="server" Text="MONTHLY TIMELOG" Style="font-family: 'Bebas Neue'; font-size: 25px; margin-left: 10px;"></asp:Label>
                        </div>

                        <div class="timelog-design">
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Icons/timelog.png" />
                            <asp:Label ID="Lbl_num_timelog" runat="server" Text="00" Style="font-family: 'Bebas Neue'; font-size: 50px;"></asp:Label>
                        </div>
                    </aside>
                </footer>
            </main>
            <!--End Point Main-->

            <aside class="aside-right-25">
                <div class="view-login">
                    <div class="view-img-login">
                        <asp:Image ID="Image9" runat="server" Height="170" Width="170" Style="margin-top: 10px;" />
                    </div>

                    <div class="view-id-login">
                        <asp:Label ID="Lbl_view_id_login" runat="server" Text="777000" Style="font-family: 'Bebas Neue'; font-size: 30px;"></asp:Label>
                    </div>

                    <div class="view-status-login">
                        <asp:Image ID="Image10" runat="server" Height="30px" Width="30px" Style="margin-right: 10px;" ImageUrl="~/Images/Icons/status-login.png" />
                        <asp:Label ID="Lbl_view_status_login" runat="server" Text="LOGGED IN" Style="color: #00ff00; font-family: 'Bebas Neue'; font-size: 20px;"></asp:Label>
                    </div>
                </div>

                <div class="view-logout">
                    <div class="view-img-logout">
                        <asp:Image ID="Image11" runat="server" Height="170" Width="170" Style="margin-top: 10px;" />
                    </div>

                    <div class="view-id-logout">
                        <asp:Label ID="Lbl_view_id_logout" runat="server" Text="777000" Style="font-family: 'Bebas Neue'; font-size: 30px;"></asp:Label>
                    </div>

                    <div class="view-status-logout">
                        <asp:Image ID="Image12" runat="server" Height="30px" Width="30px" Style="margin-right: 10px;" ImageUrl="~/Images/Icons/status-logout.png" />
                        <asp:Label ID="Lbl_view_logout" runat="server" Text="LOGGED OUT" Style="color: #ff0000; font-family: 'Bebas Neue'; font-size: 20px;"></asp:Label>
                    </div>
                </div>

                <div class="contact-dev">
                    <asp:ImageButton ID="Img_btn_call" runat="server" ImageUrl="~/Images/Icons/admin-call.PNG" Height="40" Width="40" />
                    <asp:ImageButton ID="Img_btn_fb" runat="server" ImageUrl="~/Images/Icons/admin-facebook.PNG" Height="40" Width="40" />
                    <asp:ImageButton ID="Img_btn_git" runat="server" ImageUrl="~/Images/Icons/admin-github.PNG" Height="40" Width="40" />
                </div>
            </aside>

            <footer class="footer-5">
                Under Development: 05/23/2023
            </footer>

        </div>
    </form>
</body>
</html>
