Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.IO
Imports System.Drawing
Imports System.Xml
Imports System.Web.UI

Public Class CreatorResources
	Private Const watermarkText As String = "ASPxPopupControl Demo", largeImagePostFix As String = "_large", fontName As String = "Tahoma"
	Private Const fontSize As Single = 11
	Private ReadOnly fontColor As Color = Color.FromArgb(80, Color.Gray)

	Public Sub CreateThumbnailImages(ByVal thumbnailSize As Size, ByVal largeSize As Size, ByVal originalImagesPath As String, ByVal thumbnailImagePath As String, ByVal xmlFileName As String)
		Dim xmlDocument As XmlDocument = CreateXmlDocument()
		Dim rootElement As XmlElement = CreateXmlElement(xmlDocument, Nothing, "dsImages")

		Dim index = 0
		For Each imageSourceName In Directory.GetFiles(originalImagesPath)
			Dim thumbnailImagefileName = Path.GetFileName(imageSourceName)
			Dim largeImageFileName = thumbnailImagefileName.Insert(thumbnailImagefileName.IndexOf("."c), largeImagePostFix)
			Dim actualLargeImageSize = New Size()

			Using imageSource = Bitmap.FromFile(imageSourceName)
				Using thumbnailImage = GetThumbnailImage(imageSource, thumbnailSize)
					thumbnailImage.Save(thumbnailImagePath & thumbnailImagefileName)
				End Using
				Using largeImage = GetThumbnailImage(imageSource, largeSize)
					actualLargeImageSize.Width = largeImage.Width
					actualLargeImageSize.Height = largeImage.Height
					SetWatermark(largeImage)
					largeImage.Save(thumbnailImagePath & largeImageFileName)
				End Using
			End Using

			Dim relativeImagePath As String = String.Format("{0}/", New DirectoryInfo(thumbnailImagePath).Name)

			Dim element As XmlElement = CreateXmlElement(xmlDocument, rootElement, "Image")
			AddAttribute(xmlDocument, element, "ID", index)
			AddAttribute(xmlDocument, element, "Description", Path.GetFileNameWithoutExtension(imageSourceName))
			AddAttribute(xmlDocument, element, "ImageUrl", relativeImagePath & thumbnailImagefileName)
			AddAttribute(xmlDocument, element, "LargeImageUrl", relativeImagePath & largeImageFileName)
			AddAttribute(xmlDocument, element, "Width", actualLargeImageSize.Width)
			AddAttribute(xmlDocument, element, "Height", actualLargeImageSize.Height)

			index += 1
		Next imageSourceName

		xmlDocument.Save(xmlFileName)
	End Sub

	Private Function GetThumbnailImage(ByVal image As Image, ByVal size As Size) As Image
		Dim proportion = CSng(size.Width) / image.Width
		Dim width = size.Width
		Dim height = CInt(Fix(proportion * image.Height))
		If height > size.Height Then
			proportion = CSng(size.Height) / image.Height
			height = size.Height
			width = CInt(Fix(proportion * image.Width))
		End If
		Return image.GetThumbnailImage(width, height, Nothing, IntPtr.Zero)
	End Function
	Private Sub SetWatermark(ByVal image As Image)
		Using graphics As Graphics = Graphics.FromImage(image)
			Using font As New Font(fontName, fontSize)
				Dim stringSize As SizeF = graphics.MeasureString(watermarkText, font)
				graphics.TranslateTransform(image.Width - stringSize.Height, image.Height)
				graphics.RotateTransform(-90)
				graphics.DrawString(watermarkText, font, New SolidBrush(fontColor), 5, -2)
			End Using
		End Using
	End Sub
	Private Function CreateXmlDocument() As XmlDocument
		Dim document As New XmlDocument()
		Dim dec As XmlDeclaration = document.CreateXmlDeclaration("1.0", Nothing, Nothing)
		document.AppendChild(dec)
		Return document
	End Function
	Private Function CreateXmlElement(ByVal document As XmlDocument, ByVal rootElement As XmlElement, ByVal elementName As String) As XmlElement
		Dim element As XmlElement = document.CreateElement(elementName)
		If rootElement Is Nothing Then
			document.AppendChild(element)
		Else
			rootElement.AppendChild(element)
		End If
		Return element
	End Function
	Private Sub AddAttribute(ByVal document As XmlDocument, ByVal element As XmlElement, ByVal name As String, ByVal value As Object)
		Dim attribute As XmlAttribute = document.CreateAttribute(name)
		attribute.InnerText = value.ToString()
		element.Attributes.Append(attribute)
	End Sub
End Class