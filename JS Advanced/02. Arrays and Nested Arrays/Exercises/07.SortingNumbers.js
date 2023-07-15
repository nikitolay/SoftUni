function sortingNumbers(array) {
  array.sort((a, b) => a - b);
  let result = [];
  for (let i = 0; i < array.length / 2; i++) {
    result.push(array[i]);
    result.push(array[array.length - 1 - i]);
  }
  return result;
}
console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
