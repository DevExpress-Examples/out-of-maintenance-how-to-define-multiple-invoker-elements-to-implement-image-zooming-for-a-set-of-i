using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Xml;
using System.Web.UI;

public class CreatorResources
{
    const string watermarkText = "ASPxPopupControl Demo",
                 largeImagePostFix = "_large",
                 fontName = "Tahoma";
    const float fontSize = 11;
    readonly Color fontColor = Color.FromArgb(80, Color.Gray);

    public void CreateThumbnailImages(Size thumbnailSize, Size largeSize, string originalImagesPath, string thumbnailImagePath, string xmlFileName) {
        XmlDocument xmlDocument = CreateXmlDocument();
        XmlElement rootElement = CreateXmlElement(xmlDocument, null, "dsImages");

        var index = 0;
        foreach(var imageSourceName in Directory.GetFiles(originalImagesPath)) {
            var thumbnailImagefileName = Path.GetFileName(imageSourceName);
            var largeImageFileName = thumbnailImagefileName.Insert(thumbnailImagefileName.IndexOf('.'), largeImagePostFix);
            var actualLargeImageSize = new Size();

            using(var imageSource = Bitmap.FromFile(imageSourceName)) {
                using(var thumbnailImage = GetThumbnailImage(imageSource, thumbnailSize)) {
                    thumbnailImage.Save(thumbnailImagePath + thumbnailImagefileName);
                }
                using(var largeImage = GetThumbnailImage(imageSource, largeSize)) {
                    actualLargeImageSize.Width = largeImage.Width;
                    actualLargeImageSize.Height = largeImage.Height;
                    SetWatermark(largeImage);
                    largeImage.Save(thumbnailImagePath + largeImageFileName);
                }
            }

            string relativeImagePath = string.Format("{0}/", new DirectoryInfo(thumbnailImagePath).Name);

            XmlElement element = CreateXmlElement(xmlDocument, rootElement, "Image");
            AddAttribute(xmlDocument, element, "ID", index);
            AddAttribute(xmlDocument, element, "Description", Path.GetFileNameWithoutExtension(imageSourceName));
            AddAttribute(xmlDocument, element, "ImageUrl", relativeImagePath + thumbnailImagefileName);
            AddAttribute(xmlDocument, element, "LargeImageUrl", relativeImagePath + largeImageFileName);
            AddAttribute(xmlDocument, element, "Width", actualLargeImageSize.Width);
            AddAttribute(xmlDocument, element, "Height", actualLargeImageSize.Height);

            index++;
        }

        xmlDocument.Save(xmlFileName);
    }

    Image GetThumbnailImage(Image image, Size size) {
        var proportion = (float)size.Width / image.Width;
        var width = size.Width;
        var height = (int)(proportion * image.Height);
        if(height > size.Height) {
            proportion = (float)size.Height / image.Height;
            height = size.Height;
            width = (int)(proportion * image.Width);
        }
        return image.GetThumbnailImage(width, height, null, IntPtr.Zero);
    }
    void SetWatermark(Image image) {
        using(Graphics graphics = Graphics.FromImage(image)) {
            using(Font font = new Font(fontName, fontSize)) {
                SizeF stringSize = graphics.MeasureString(watermarkText, font);
                graphics.TranslateTransform(image.Width - stringSize.Height, image.Height);
                graphics.RotateTransform(-90);
                graphics.DrawString(watermarkText, font, new SolidBrush(fontColor), 5, -2);
            }
        }
    }
    XmlDocument CreateXmlDocument() {
        XmlDocument document = new XmlDocument();
        XmlDeclaration dec = document.CreateXmlDeclaration("1.0", null, null);
        document.AppendChild(dec);
        return document;
    }
    XmlElement CreateXmlElement(XmlDocument document, XmlElement rootElement, string elementName) {
        XmlElement element = document.CreateElement(elementName);
        if(rootElement == null)
            document.AppendChild(element);
        else
            rootElement.AppendChild(element);
        return element;
    }
    void AddAttribute(XmlDocument document, XmlElement element, string name, object value) {
        XmlAttribute attribute = document.CreateAttribute(name);
        attribute.InnerText = value.ToString();
        element.Attributes.Append(attribute);
    }
}