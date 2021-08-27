<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128564099/12.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4023)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CreatorResources.cs](./CS/WebSite/App_Code/CreatorResources.cs) (VB: [CreatorResources.vb](./VB/WebSite/App_Code/CreatorResources.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to define multiple invoker elements to implement image zooming for a set of images
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4023/)**
<!-- run online end -->


<p>This example demonstrates how to implement a kind of an image gallery with an image preview.</p><p>Image thumbnails are displayed by ASPxDataView that is used in Flow layout mode. In this mode, image thumbnails flow one after another, to fill the available page area within the browser window in the best possible way. When hovering a thumbnail, ASPxPopupControl is invoked to display a large (zoomed) image. During zoomed image loading, ASPxPopupControl displays a thumbnail image enlarged to the zoomed image size.</p><p>The specificity of this example is that image previews are displayed with the help of a single ASPxPopupControl that is dynamically linked to multiple invoker elements via client code. The client SetPopupElementID method is used to associate ASPxPopupControl with multiple instances of a thumbnail image element placed within ASPxDataView's ItemTemplate.</p><p>From this example, you can also learn how to dynamically generate two images - thumbnail and preview - from an original image and how to apply a watermark to a large preview image.</p>

<br/>


