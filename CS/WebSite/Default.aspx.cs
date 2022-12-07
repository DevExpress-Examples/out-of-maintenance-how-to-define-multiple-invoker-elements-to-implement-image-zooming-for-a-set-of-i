using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.Internal;

public partial class Examples_Default2 : System.Web.UI.Page {
    protected void galleryDV_CustomJSProperties(object sender, CustomJSPropertiesEventArgs e) {
        var itemDetails = new Dictionary<string, object>();
        foreach(DataViewItem item in galleryDV.Items.GetVisibleItems()) {
            var key = GetImageID(GetItemValue(item, "ID"));
            itemDetails[key] = GetItemDetail(item);
        }
        e.Properties["cpItemDetails"] = itemDetails;
    }
    protected object GetItemDetail(DataViewItem item) {
        Dictionary<string, object> itemDetail = new Dictionary<string, object>();
        itemDetail.Add("description", GetItemValue(item, "Description"));
        itemDetail.Add("highQualityImageUrl", GetItemValue(item, "LargeImageUrl"));
        itemDetail.Add("imageWidth", GetItemValue(item, "Width"));
        itemDetail.Add("imageHeight", GetItemValue(item, "Height"));
        return itemDetail;
    }
    protected object GetItemValue(DataViewItem item, string fieldName) {
        return DataBinder.Eval(item.DataItem, fieldName);
    }
    protected string GetImageID(object id) {
        return string.Format("img_{0}", id);
    }
}