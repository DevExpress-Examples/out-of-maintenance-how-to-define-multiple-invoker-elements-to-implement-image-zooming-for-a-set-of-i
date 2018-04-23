# How to define multiple invoker elements to implement image zooming for a set of images


<p>This example demonstrates how to implement a kind of an image gallery with an image preview.</p><p>Image thumbnails are displayed by ASPxDataView that is used in Flow layout mode. In this mode, image thumbnails flow one after another, to fill the available page area within the browser window in the best possible way. When hovering a thumbnail, ASPxPopupControl is invoked to display a large (zoomed) image. During zoomed image loading, ASPxPopupControl displays a thumbnail image enlarged to the zoomed image size.</p><p>The specificity of this example is that image previews are displayed with the help of a single ASPxPopupControl that is dynamically linked to multiple invoker elements via client code. The client SetPopupElementID method is used to associate ASPxPopupControl with multiple instances of a thumbnail image element placed within ASPxDataView's ItemTemplate.</p><p>From this example, you can also learn how to dynamically generate two images - thumbnail and preview - from an original image and how to apply a watermark to a large preview image.</p>

<br/>


