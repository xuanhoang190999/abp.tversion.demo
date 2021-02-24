export abstract class StringUtils {         
    public static replace(sTemplate, mData): string {
        if (typeof sTemplate === "string") {
            // mData = mData instanceof Object ? mData : {};
            mData = mData ? mData : {};
            return sTemplate.replace(/\$\{\s*([$#@\-\d\w]+)\s*\}/gim, function (fullMath, grp) {
                let val = mData[grp];
                if (typeof val === "function") {
                    val = val();
                } else if (val === null || val === undefined) {
                    val = "";
                } else if (typeof val === "object" || typeof val === "symbol") {
                    val = val.toString();
                } else {
                    val = val.valueOf();
                }
                return val;
            });
        }
        return "";
    }
}