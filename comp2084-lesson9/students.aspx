<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="comp2084_lesson9.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Students</h1>

    <a href="student-details.aspx" class="btn btn-primary">Add Student</a>

    <asp:GridView runat="server" ID="grdStudents" AutoGenerateColumns="false" AllowPaging="true" PageSize="3" OnPageIndexChanging="grdStudents_PageIndexChanging" OnRowDeleting="grdStudents_RowDeleting" DataKeyNames="StudentID" CssClass="table table-striped table-hover" >
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="ID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="student-details.aspx?StudentID={0}" ControlStyle-CssClass="btn btn-default"/>
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>

</asp:Content>
