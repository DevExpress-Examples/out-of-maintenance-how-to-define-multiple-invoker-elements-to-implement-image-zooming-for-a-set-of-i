<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Examples_Default2" %>
<%@ Register Assembly="DevExpress.Web.v13.1" Namespace="DevExpress.Web"
    TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function galleryDV_Init(s,e) {
            InitializePopupElements();
        }
        function galleryDV_EndCallBack() {
            InitializePopupElements();
        }
        function popup_Popup(s, e) {
            var popupElement = s.GetCurrentPopupElement();
            var itemDetail = galleryDV.cpItemDetails[popupElement.id];
            var lowQualityImage = document.getElementById("lowQualityImage");
            var description = document.getElementById("description");
            var highQualityImageWrapper = document.getElementById("highQualityImageWrapper");
            var highQualityImage = document.createElement("IMG");

            highQualityImageWrapper.innerHTML = "";
            highQualityImageWrapper.appendChild(highQualityImage);
            highQualityImageWrapper.style.marginTop = "-" + itemDetail.imageHeight + "px";
            highQualityImageWrapper.style.width = itemDetail.imageWidth + "px";
            highQualityImageWrapper.style.height = itemDetail.imageHeight + "px";
            
            lowQualityImage.src = popupElement.src;
            lowQualityImage.width = itemDetail.imageWidth;
            lowQualityImage.height = itemDetail.imageHeight;
            lowQualityImage.alt = itemDetail.description;
            
            highQualityImage.src = itemDetail.highQualityImageUrl;
            highQualityImage.alt = itemDetail.description;
            description.innerHTML = itemDetail.description;

            s.UpdatePosition();
        }
        function InitializePopupElements() {
            var imageIDs = [ ];
            for(var id in galleryDV.cpItemDetails)
                imageIDs.push(id)
            popup.SetPopupElementID(imageIDs.join(";"));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <p>To zoom a thumbnail image, move the mouse cursor over it.</p>
    <div class="panel">
        <dx:ASPxDataView ID="galleryDV" ClientInstanceName="galleryDV" runat="server" 
            EnableViewState="false" DataSourceID="XmlHomes"
            OnCustomJSProperties="galleryDV_CustomJSProperties" Layout="Flow" PagerAlign="Justify"
            ItemSpacing="0" ColumnCount="10" RowPerPage="2">
            <ItemTemplate>
                <div align="center" class="imageWrapper">
                    <a href="javascript:;">
                        <img id='<%# GetImageID(Eval("ID"))%>' src='<%# Eval("ImageUrl")%>' alt='<%# Eval("Description") %>' class="thumbnailImage" />
                    </a>
                </div>
            </ItemTemplate>
            <PagerSettings ShowNumericButtons="true">
                <AllButton Visible="False" />
                <Summary Visible="false" />
                <PageSizeItemSettings Visible="true" ShowAllItem="true" 
                    Items="10, 20, 30, 60" />
            </PagerSettings>
            <ClientSideEvents Init="galleryDV_Init" EndCallback="galleryDV_EndCallBack" />
        </dx:ASPxDataView>
    </div>
    <dx:ASPxPopupControl ID="popup" ClientInstanceName="popup" runat="server" EnableViewState="false" ShowHeader="false"
        EnableAnimation="false" PopupHorizontalAlign="OutsideRight" PopupVerticalAlign="TopSides"
        PopupAction="MouseOver" CloseAction="MouseOut" AppearAfter="0" DisappearAfter="0"
        PopupHorizontalOffset="18" PopupVerticalOffset="-60">
            <ContentCollection>
                <dx:PopupControlContentControl>
                    <img id="lowQualityImage" src="" alt="" />
                    <div id="highQualityImageWrapper"></div>
                    <p id="description"></p>
                </dx:PopupControlContentControl>
            </ContentCollection>
        <ClientSideEvents PopUp="popup_Popup" />
    </dx:ASPxPopupControl>
    <asp:XmlDataSource ID="XmlHomes" runat="server" DataFile="~/App_Data/Gallery.xml"
        XPath="//dsImages/Image"></asp:XmlDataSource>
    </form>
</body>
</html>
