using System;
using System.Drawing;

public partial class scripts_Default : System.Web.UI.Page {
    const string originalImagesPath = @"C:\originalImage\",
                 thumbnailImagePath = @"images\",
                 xmlFilePath = @"App_Data\",
                 xmlFileName = "Gallery.xml";

    CreatorResources creator = new CreatorResources();

    protected void Click(object sender, EventArgs e) {
        var thumbnailImageSize = new Size(int.Parse(thumbnailWidth.Text), int.Parse(thumbnailHeght.Text));
        var largeImageSize = new Size(int.Parse(largeWidth.Text), int.Parse(largeHeght.Text));

        creator.CreateThumbnailImages(thumbnailImageSize, largeImageSize, originalImagesPath, Server.MapPath(thumbnailImagePath), Server.MapPath(xmlFilePath) + xmlFileName);

        lblProgress.Visible = true;
    }
}