export function mergeArray(arr1, arr2): any[] {
    if (!arr1) return arr2;
    if (!arr2) return arr1;

    return [...arr1, ...arr2];
}

export function makeUniqueArray(arr1, arr2, fied): any[] {
    let arr = mergeArray(arr1, arr2);

    let unique = arr
        .map(item => item[fied])
        // store the keys of the unique objects
        .map((item, i, final) => final.indexOf(item) === i && i)
        // eliminate the duplicate keys & store unique objects
        .filter(item => arr[item]).map(item => arr[item]);

    return unique;
}
