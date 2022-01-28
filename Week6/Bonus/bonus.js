let arr = ["asli", "menekşe", "çöz", "giresun"];


let result = [];

for (i = 0; i < arr.length; i++) {

  let result1 = arr[i].match(/q|w|e|r|t|y|u|ı|o|p|ğ|ü/g);
  let result2 = arr[i].match(/a|s|d|f|g|h|j|k|l|ş|i|/g);
  let result3 = arr[i].match(/z|x|c|v|b|n|m|ö|ç/g);

 
  let resultItem = [result1, result2,result3].find((item)=>{
   let  _item = item? item.join("") : "";
   return _item === arr[i];
  })

  if(resultItem){
    result.push(resultItem.join(""))
  }
}


console.log(result);

