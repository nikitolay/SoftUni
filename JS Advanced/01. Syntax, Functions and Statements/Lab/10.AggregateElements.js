function aggregateElements(array) {
  let sumAllElements = 0;
  let sumInverseValues = 0;
  let concatText = "";
  for (let index = 0; index < array.length; index++) {
    const element = Number(array[index]);
    sumAllElements += element;
    sumInverseValues += 1 / element;
    concatText += array[index];
  }
  console.log(sumAllElements);
  console.log(sumInverseValues);
  console.log(concatText);
}
aggregateElements([2, 4, 8, 16]);
