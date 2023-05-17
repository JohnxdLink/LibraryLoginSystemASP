<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="library-login.aspx.cs" Inherits="Library_Login_System.Views.library_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--
        Project: Library Login System
        Developer: Castro John Christian
        Message: StoryVerse: "Where Words Come Alive"
        Date Created: 05/10-16/2023
        -->
    <link rel="stylesheet" href="../Style/library-login.css" />
    <title>Library | Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="whole-container">
            <!--Declare the ScriptManager control for client-side scripting-->
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <!--Left-->
            <div class="left-column">
                <!--TITLE-->
                <h1 style="margin-top: 50px; margin-bottom: 15px; color: #f1916d; text-align: center; font-size: 50px;">LIBRARY LOGIN</h1>


                <!--Search ID-->
                <div>
                    <asp:Label ID="Label1" runat="server" Text="ID NO:" CssClass="lbls"></asp:Label>
                    <asp:TextBox ID="Txb_search_id" runat="server" Width="350px" Height="35px" CssClass="txb_search_design"></asp:TextBox>
                </div>

                <!--Login Buttons-->
                <div style="margin-left: 100px; margin-bottom: 20px;">
                    <asp:Button ID="Btn_login" runat="server" Text="LOGIN" CssClass="btn_design" Style="margin-right: 20px;" OnClick="Btn_login_Click" />
                    <asp:Button ID="Btn_logout" runat="server" Text="LOGOUT" CssClass="btn_design" OnClick="Btn_logout_Click" />
                </div>

                <!--Clock Container-->
                <!--
                    Timer triggers async postback every second,
                    UpdatePanel has AsyncPostBackTrigger for Timer,
                    and UpdateTime is called only on initial page load.
                    Timer1_Tick updates time every second, and only UpdatePanel content is refreshed on async postback.
                    -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="margin-left: 60px; margin-bottom: 25px; width: 400px; height: 200px; background: #f1916d; border: 5px solid #473e66; border-radius: 30px; display: flex; justify-content: center; position: relative;">

                            <div class="digital-clock" style="align-self: center;">
                                <asp:Label ID="Lbl_current_time" runat="server" Text="00:00:00" Font-Size="50" ForeColor="#06142E"></asp:Label>
                            </div>

                            <div class="date-today" style="align-self: flex-end; position: absolute; bottom: 30px; text-align: center;">
                                <asp:Label ID="Lbl_current_date" runat="server" Text="" Font-Size="20" ForeColor="#473E66" Font-Names="Bebas Neue"></asp:Label>
                            </div>

                        </div>
                    </ContentTemplate>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>

                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>

                <!--Exit Register Button-->
                <div style="margin-left: 30px;">
                    <asp:Button ID="Btn_exit" runat="server" Text="EXIT" CssClass="btn_ext_design" OnClick="Btn_exit_Click" />
                    <asp:Button ID="Btn_register" runat="server" Text="REGISTER" CssClass="btn_reg_design" OnClick="Btn_register_Click" />
                </div>

                <!--Access Granted || Access Denied-->
                <div style="margin-top: 30px; font-size: 40px; text-align: center;">
                    <asp:Label ID="Lbl_notify" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <!--Right-->
            <div class="right-column">

                <!--Login Container-->
                <div class="login-container">
                    <!--Login Image-->
                    <div class="login-image-con" style="display: inline-block; vertical-align: middle;">
                        <asp:Image ID="Img_Login" runat="server" CssClass="login_profile" />
                    </div>

                    <!--Login Form-->
                    <div class="login-form-group" style="display: inline-block; vertical-align: middle;">

                        <div>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/status-login.png" CssClass="login_form_icons" />
                            <asp:Label ID="Lbl_status" runat="server" Text="" Font-Names="Bebas Neue" Font-Size="35" ForeColor="#4CFF00"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/id.png" CssClass="login_form_icons" />
                            <asp:Label ID="Lbl_id_login" runat="server" Text="" CssClass="lbl_user_log"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Icons/name.png" CssClass="login_form_icons" />
                            <asp:Label ID="Lbl_name_login" runat="server" Text="" CssClass="lbl_user_log"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Icons/course.png" CssClass="login_form_icons" />
                            <asp:Label ID="Lbl_course_login" runat="server" Text="" CssClass="lbl_user_log" Style="width: 180px;"></asp:Label>
                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Icons/year.png" CssClass="login_form_icons" />
                            <asp:Label ID="Lbl_year_login" runat="server" Text="" CssClass="lbl_user_log"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Icons/timelog.png" Width="50" Height="50" />
                            <asp:Label ID="Lbl_timein" runat="server" Text="" Font-Names="Bebas Neue" Font-Size="35" ForeColor="#4CFF00"></asp:Label>
                        </div>
                    </div>
                </div>

                <!--Logout Container-->
                <div class="logout-container">
                    <!--Logout Image-->
                    <div class="logout-image-con" style="display: inline-block; vertical-align: middle;">
                        <asp:Image ID="Img_Logout" runat="server" CssClass="logout_profile" />
                    </div>

                    <!--Logout Form-->
                    <div class="logout-form-group" style="display: inline-block; vertical-align: middle;">

                        <div>
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Icons/status-logout.png" CssClass="logout_form_icons" />
                            <asp:Label ID="Lbl_recent_status" runat="server" Text="" Font-Names="Bebas Neue" Font-Size="35" ForeColor="#ff0000"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/Icons/recent-id.png" CssClass="logout_form_icons" />
                            <asp:Label ID="Lbl_recent_id" runat="server" Text="" CssClass="lbl_recent_user_log"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/Icons/recent-name.png" CssClass="logout_form_icons" />
                            <asp:Label ID="Lbl_recent_name" runat="server" Text="" CssClass="lbl_recent_user_log"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/Icons/recent-course.png" CssClass="logout_form_icons" />
                            <asp:Label ID="Lbl_recent_course" runat="server" Text="" CssClass="lbl_recent_user_log" Style="width: 180px;"></asp:Label>
                            <asp:Image ID="Image13" runat="server" ImageUrl="~/Images/Icons/recent-year.png" CssClass="login_form_icons" />
                            <asp:Label ID="Lbl_recent_year" runat="server" Text="" CssClass="lbl_recent_user_log"></asp:Label>
                        </div>

                        <div>
                            <asp:Image ID="Image14" runat="server" ImageUrl="~/Images/Icons/recent-timelog.png" Width="50" Height="50" />
                            <asp:Label ID="Lbl_timeout" runat="server" Text="" Font-Names="Bebas Neue" Font-Size="35" ForeColor="#ff0000"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
