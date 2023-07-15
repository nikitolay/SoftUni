function extractIncreasingSubset(array) {
  let arrayLength = array.length;
  for (let i = 1; i <= arrayLength; i++) {
    if (array[i] < array[i - 1]) {
      array.splice(i, 1);
      i--;
    }
  }
  console.log(array.join("\n"));
}
extractIncreasingSubset([20, 3, 2, 15, 6, 1]);
