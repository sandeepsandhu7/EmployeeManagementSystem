﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpJob.aspx.cs" Inherits="EmployeeManagementSystem.EmpJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputName">Job <span style="color: red;">*</span></label>
                <asp:TextBox ID="JobName" class="form-control" runat="server" placeholder="Job"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorJobName" ValidationGroup="Save" runat="server" ControlToValidate="JobName" ErrorMessage="Please enter job name" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputMinSalary">Min Salary <span style="color: red;">*</span></label>
                <asp:TextBox ID="MinSalary" class="form-control" runat="server" placeholder="Min Salary"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ControlToValidate="MinSalary" ErrorMessage="Please enter minimum salary" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="exampleInputMaxSalary">Max Salary <span style="color: red;">*</span></label>
                <asp:TextBox ID="MaxSalary" class="form-control" runat="server" placeholder="Max Salary"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Save" runat="server" ControlToValidate="MaxSalary" ErrorMessage="Please enter maximum salary" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-success pull-right" Text="Submit" OnClick="Submit_Click" />
            <asp:Button ID="Reset" runat="server" class="btn btn-danger pull-right" Text="Reset" OnClick="Reset_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">

                <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover"
                    AutoGenerateColumns="false" EmptyDataText="No Record Found" DataKeyNames="ID"
                    AllowPaging="false" PageSize="10" OnRowCommand="grd_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Job
                           
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("Job") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MinSalary" HeaderText="Min Salary" />
                        <asp:BoundField DataField="MaxSalary" HeaderText="Max Salary" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


        </div>
    </div>
</asp:Content>
