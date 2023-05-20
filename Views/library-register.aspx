<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="library-register.aspx.cs" Inherits="Library_Login_System.Views.library_register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--
        Project: Library Login System
        Developer: Castro John Christian
        Message: StoryVerse: "Where Words Come Alive"
        Date Created: 05/10-16/2023
        -->
    <link rel="stylesheet" href="../Style/library-register.css" />
    <title>Library | Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br /> <br /> <br />

            <div class="container">
                <div>
                    <asp:ImageButton ID="imgbtnhome" runat="server" ImageUrl="~/Images/Icons/home.PNG" Height="30" Width="30" OnClick="imgbtnhome_Click" />
                    <asp:ImageButton ID="imgbtnregister" runat="server" ImageUrl="~/Images/Icons/register sign.PNG" Height="30" Width="30" OnClick="imgbtnregister_Click" />
                    <asp:ImageButton ID="imgbtnlogin" runat="server" ImageUrl="~/Images/Icons/proceed.PNG" Height="30" Width="30" OnClick="imgbtnlogin_Click" />
                </div>
                <h2>REGISTRATION FORM</h2>
                <div class="row">
                    <div class="col-25">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/course id.PNG" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtId">ID NO <span style="color: #808080;"> (Auto.)</span></label>
                        <asp:TextBox ID="txtId" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="col-75">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/course name.PNG" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtLastName">LAST NAME</label>
                        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-25">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/course name.PNG" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtFirstName">FIRST NAME</label>
                        <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-75">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/course course.png" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtCourse">COURSE<span style="color: #808080;"> (Ex. BSIT)</span></label>
                        <asp:TextBox ID="txtCourse" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-25">
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Icons/course year.PNG" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtYear">YEAR <span style="color: #808080;"> (Ex. 1...)</span></label>
                        <asp:TextBox ID="txtYear" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-75">
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Icons/course major.PNG" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtMajor">MAJOR</label>
                        <asp:TextBox ID="txtMajor" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>

                </div>
                <div class="row">
                    <div class="col-25">
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Icons/course photo.png" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtPhoto">PHOTO</label>
                        <asp:TextBox ID="txtPhoto" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:FileUpload ID="UploadingFile" runat="server" />
                    </div>

                    <div class="col-75">
                        <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Icons/course notify.png" Height="30px" Width="30px" ImageAlign="Left" Style="margin-right: 5px;" />
                        <label for="txtNotification">NOTIFICATION</label>
                        <asp:Label ID="register_notify" runat="server" Text="CLICK EDIT" Font-Size="X-Large" ForeColor="#1b3358"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <asp:Button ID="btnEdit" runat="server" Text="EDIT" CssClass="button" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="CLEAR" CssClass="button" OnClick="btnClear_Click" />
                    <asp:Button ID="btnRegister" runat="server" Text="REGISTER" CssClass="button" OnClick="btnRegister_Click" />
                    <asp:Button ID="btnLogin" runat="server" Text="LOGIN" CssClass="button" Width="150" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
