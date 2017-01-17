<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyReg.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/css/bootstrap.min.css" integrity="sha384-rwoIResjU2yc3z8GV/NPeZWAv56rSmLldC3R/AZzGRnGxQQKnKkoFVhFQhNUwEyJ" crossorigin="anonymous">
<script src="https://code.jquery.com/jquery-3.1.1.slim.min.js" integrity="sha384-A7FZj7v+d/sdmMqp/nOQwliLvUsJfDHW+k9Omg/a/EheAdgtzNs3hpfag6Ed950n" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-alpha.6/js/bootstrap.min.js" integrity="sha384-vBWWzlZJ8ea9aCX4pEW3rVHjgjt7zpkNpZk+02D9phzyeVkE+jo0ieGizqPLForn" crossorigin="anonymous"></script>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
      $("#datepicker").datepicker({
          dateFormat: "dd/mm/yy"
      });
      $("#datepicker").change(function () {


          /*Ajax To Get Age, Populate Hidden field. */
          $.get("GetAge.aspx",
            {
                dob: $("#datepicker").val()
            },
            function (data) {
                document.getElementById("calculatedAge").value = data;
                //alert($("#calculatedAge").val());
            });

      });

      
      

  });

  </script>

    <title></title>
</head>
<body>
    <h1>Sign Up.</h1>
    <div class="container bg-faded card">
    <form id="Form1" runat="server">
    <div class="form-group row">

        </div>

    <div class="form-group row">
        <asp:Label ID="lblTitle" class="col-2 col-form-label" AssociatedControlID="inTitle" runat="server" Text="Title"></asp:Label>
        <div class="col-5">
            <asp:DropDownList class="custom-select mb-2 mr-sm-2 mb-sm-0" ID="inTitle" runat="server">
                <asp:ListItem value="">Choose</asp:ListItem>
                <asp:ListItem value="Mr">Mr</asp:ListItem>
                <asp:ListItem value="Mrs">Mrs</asp:ListItem>
                <asp:ListItem value="Dr">Dr</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please choose a salutation / Title." ControlToValidate="inTitle" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-group row">
        <asp:Label ID="lblFirstName" class="col-2 col-form-label" AssociatedControlID="inFirstName" runat="server" Text="Name"></asp:Label>
        <div class="col-5">
        <asp:TextBox ID="inFirstName"  class="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your name" ControlToValidate="inFirstName">*</asp:RequiredFieldValidator>
        </div>
    </div>


    <div class="form-group row">
        <asp:Label ID="lblSurname" class="col-2 col-form-label" AssociatedControlID="inSurname" runat="server" Text="Surname"></asp:Label>
        <div class="col-5"> <asp:TextBox  class="form-control" ID="inSurname" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter your surname" ControlToValidate="inSurname">*</asp:RequiredFieldValidator> </div>
    </div>


    <div class="form-group row">
        <asp:Label ID="lblEmail" AssociatedControlID="inEmail"  class="col-2 col-form-label" runat="server" Text="Email"></asp:Label>
        <div class="col-5">
            <asp:TextBox ID="inEmail"  class="form-control"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter your email address" ControlToValidate="inEmail">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="inEmail" ErrorMessage="Must be a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="field-error"></asp:RegularExpressionValidator>
        </div>
    </div>


    <div class="form-group row">
        <asp:Label ID="lblEmail2" AssociatedControlID="inEmail2" class="col-2 col-form-label" runat="server" Text="Re-enter your email address"></asp:Label>
        <div class="col-5">
            <asp:TextBox  class="form-control" ID="inEmail2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please re-enter your email address" ControlToValidate="inEmail2">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Email addresses do not match" ControlToCompare="inEmail" ControlToValidate="inEmail2"></asp:CompareValidator>
        </div>
    </div>


    
     <div class="form-group row">
            <asp:Label ID="lblDatepicker" AssociatedControlID="datepicker"  class="col-2 col-form-label" runat="server" Text="Date of Birth"></asp:Label>
            <div class="col-5">
                <asp:TextBox ID="datepicker"  class="form-control" runat="server" ></asp:TextBox>
                
                <input type="hidden" name="calculatedAge" id="calculatedAge" runat="server" value="" class="calculatedAge"  />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter your date of birth." ControlToValidate="datepicker">*</asp:RequiredFieldValidator>

            </div>
      </div>



    <div class="form-group row">
        <div class="col-5">
            <asp:Button ID="submit" Text="Submit"  class="btn btn-primary" runat="server" OnClick="submit_Click"></asp:Button>
        </div> 
    </div>
    <div class="form-group row">
        <div class="col-5">
            <asp:Label ID="MyErrorLabel" runat="server" Text=""></asp:Label>
        </div> 
    </div>
 </form>
</div>
</body>
</html>
