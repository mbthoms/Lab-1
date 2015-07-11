<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="comp2084_lesson9.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Student Details</h1>

    <h5>All fields are required</h5>
    <div class="form-group">
        <label for="txtLastName" class="col-sm-2">Last Name: *</label>
        <asp:textbox ID="txtLastName" MaxLength="50" required runat="server" />
    </div>
    <div class="form-group">
        <label for="txtFirstMidName" class="col-sm-2">First Name: *</label>
        <asp:textbox ID="txtFirstMidName" runat="server" />
    </div>
    <div class="col-sm-offset-2">
        <asp:button text="Save" ID="btnSave" CssClass="btn btn-primary" runat="server" onclick="btnSave_Click" />
    </div>
</asp:Content>
