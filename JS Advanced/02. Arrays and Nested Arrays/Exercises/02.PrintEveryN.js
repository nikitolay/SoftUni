function printEveryN(array, nStep) {
  let resultArray = [];

  for (let i = 0; i < array.length; i += nStep) {
    resultArray.push(array[i]);
  }
  return resultArray;
}
console.log(printEveryN(["1", "2", "3", "4", "5"], 6));
