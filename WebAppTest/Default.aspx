<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppTest.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DB-App</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background: #fafafa;
            margin: 0;
            padding: 20px;
        }

        h1 {
            color: #333;
            margin-bottom: 20px;
        }

        .card {
            background: white;
            padding: 20px;
            margin-bottom: 25px;
            border-radius: 8px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
            max-width: 500px;
        }

        .card h2 {
            margin-top: 0;
            color: #04AA6D;
        }

        label {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }

        input[type=text], .aspNetTextBox {
            width: 100%;
            padding: 8px;
            margin-top: 4px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btn {
            margin-top: 15px;
            padding: 10px 15px;
            background-color: #04AA6D;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #038e5a;
        }

        /* GridView styling */
        table {
            border-collapse: collapse;
            width: 100%;
            margin-top: 25px;
        }

        th, td {
            text-align: left;
            padding: 10px;
        }

        tr:nth-child(even) { background-color: #f2f2f2; }

        th {
            background-color: #04AA6D;
            color: white;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <h1>Din første DB-app</h1>

        <!-- Søk på etternavn -->
        <div class="card">
            <h2>Search lastname</h2>

            <label for="TextBoxLastName">Lastname</label>
            <asp:TextBox ID="TextBoxLastNameSearch" runat="server" CssClass="aspNetTextBox"></asp:TextBox>

            <asp:Button ID="ButtonSearchLastName" runat="server" Text="Søk" CssClass="btn"
                OnClick="ButtonSearchLastName_Click" />
        </div>

        <!-- Søk på fornavn -->
        <div class="card">
            <h2>Search firstname - få denne til å virke</h2>

            <label for="TextBoxFirstName">Firstname</label>
            <asp:TextBox ID="TextBoxFirstNameSearch" runat="server" CssClass="aspNetTextBox"></asp:TextBox>
        </div>

        <!-- Sett inn person -->
        <div class="card">
            <h2>Sett inn ny person</h2>

            <asp:Label ID="LabelFirstName" runat="server" Text="Firstname"></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server" CssClass="aspNetTextBox"></asp:TextBox>

            <asp:Label ID="LabelLastName" runat="server" Text="Lastname"></asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server" CssClass="aspNetTextBox"></asp:TextBox>

            <asp:Label ID="LabelAddress" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="aspNetTextBox"></asp:TextBox>

            <asp:Label ID="LabelPostalCode" runat="server" Text="Postalcode"></asp:Label>
            <asp:TextBox ID="TextBoxPostalCode" runat="server" CssClass="aspNetTextBox"></asp:TextBox>

            <asp:Button ID="ButtonInsertPerson" runat="server" Text="Sett inn person" CssClass="btn"
                OnClick="ButtonInsertPerson_Click1" />
        </div>

        <hr />
        <h3>Show all persons - henter kun fra 1 tabell, her kan vi joine</h3>
        <asp:Button ID="ButtonShowAllPersons" runat="server" Text="Show all persons" CssClass="btn" OnClick="ButtonShowAllPersons_Click"/>

        <!-- Resultattabell -->
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>

    </form>
</body>
</html>
