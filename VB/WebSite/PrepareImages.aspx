'INSTANT VB NOTE: This code snippet uses implicit typing. You will need to set 'Option Infer On' in the VB file or set 'Option Infer' at the project level:

<%@ Page Language="vb" AutoEventWireup="true" CodeFile="PrepareImages.aspx.vb" Inherits="scripts_Default" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web"
	TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<table>
			<tr>
				<td>
					<dx:ASPxLabel runat="server" Text="thumbnail image width" AssociatedControlID="thumbnailWidth" />
				</td>
				<td>
					<dx:ASPxTextBox ID="thumbnailWidth" runat="server" Text="110" Width="100" />
				</td>
				<td>
					<dx:ASPxLabel runat="server" Text="thumbnail image heght" AssociatedControlID="thumbnailHeght" />
				</td>
				<td>
					<dx:ASPxTextBox ID="thumbnailHeght" runat="server" Text="110" Width="100" />
				</td>
			</tr>
			<tr>
				<td>
					<dx:ASPxLabel runat="server" Text="large image width" AssociatedControlID="thumbnailWidth" />
				</td>
				<td>
					<dx:ASPxTextBox ID="largeWidth" runat="server" Text="380" Width="100" />
				</td>
				<td>
					<dx:ASPxLabel runat="server" Text="thumbnail image heght" AssociatedControlID="largeHeght" />
				</td>
				<td>
					<dx:ASPxTextBox ID="largeHeght" runat="server" Text="380" Width="100" />
				</td>
			</tr>
			<tr>
				<dx:ASPxButton runat="server" Text="Apply" OnClick="Click" />
			</tr>
			<tr>
				<td>
					<dx:ASPxLabel ID="lblProgress" runat="server" Visible="false" Text="Finished" />
				</td>
			</tr>
		</table>
	</form>
</body>
</html>