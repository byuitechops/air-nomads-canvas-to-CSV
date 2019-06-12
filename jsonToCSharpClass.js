var header = "namespace YOUR_NAMESPACE_HERE {\n\t public class YOUR_CLASS_NAME_HERE {\n";
var footer = "\n\t}\n}";

try{

    var fs = require('fs');
    var json = JSON.parse(fs.readFileSync(process.argv[2]));
    console.log(json);
    var keys = [];
    for (var i in json) {
        keys.push(`public ${getType(json[i])} ${i} {get;set;}`);
    }
    var file = "\n\t\t" + keys.join("\n\t\t");
    fs.writeFileSync(process.argv[3], header+file+footer);
}catch(e){
    console.log("U durn messedup boy!\n");
    console.error (e.message);
}

function getType(thinggy){
    var type = typeof(thinggy);
    if(type === "number")
        type = "double";
    if(type === "object")
        type = "string";
    if(type === "boolean")
            type = "bool";
    return type;
}

