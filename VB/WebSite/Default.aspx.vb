Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.Web.ASPxClasses.Internal
Imports DevExpress.Web.ASPxDataView

Partial Public Class Examples_Default2
	Inherits System.Web.UI.Page
	Protected Sub galleryDV_CustomJSProperties(ByVal sender As Object, ByVal e As CustomJSPropertiesEventArgs)
		Dim itemDetails = New Dictionary(Of String, Object)()
		For Each item As DataViewItem In galleryDV.Items.GetVisibleItems()
			Dim key = GetImageID(GetItemValue(item, "ID"))
			itemDetails(key) = GetItemDetail(item)
		Next item
		e.Properties("cpItemDetails") = itemDetails
	End Sub
	Protected Function GetItemDetail(ByVal item As DataViewItem) As Object
		Dim itemDetail As New Dictionary(Of String, Object)()
		itemDetail.Add("description", GetItemValue(item, "Description"))
		itemDetail.Add("highQualityImageUrl", GetItemValue(item, "LargeImageUrl"))
		itemDetail.Add("imageWidth", GetItemValue(item, "Width"))
		itemDetail.Add("imageHeight", GetItemValue(item, "Height"))
		Return itemDetail
	End Function
	Protected Function GetItemValue(ByVal item As DataViewItem, ByVal fieldName As String) As Object
		Return DataBinder.Eval(item.DataItem, fieldName)
	End Function
	Protected Function GetImageID(ByVal id As Object) As String
		Return String.Format("img_{0}", id)
	End Function
End Class