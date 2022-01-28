const array = [2,3,4]

const girlsPowerSum = (n)=>{
    let result = n + (n/2) + 3
    return result;
}
const  girlsPower = (arr, sum) => arr.map((item)=> sum(item));

console.log(girlsPower(array,girlsPowerSum));
