Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing

Partial Public Class scripts_Default
	Inherits System.Web.UI.Page
	Private Const originalImagesPath As String = "C:\originalImage\", thumbnailImagePath As String = "images\", xmlFilePath As String = "App_Data\", xmlFileName As String = "Gallery.xml"

	Private creator As New CreatorResources()

	Protected Sub Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim thumbnailImageSize = New Size(Integer.Parse(thumbnailWidth.Text), Integer.Parse(thumbnailHeght.Text))
		Dim largeImageSize = New Size(Integer.Parse(largeWidth.Text), Integer.Parse(largeHeght.Text))

		creator.CreateThumbnailImages(thumbnailImageSize, largeImageSize, originalImagesPath, Server.MapPath(thumbnailImagePath), Server.MapPath(xmlFilePath) & xmlFileName)

		lblProgress.Visible = True
	End Sub
End Class