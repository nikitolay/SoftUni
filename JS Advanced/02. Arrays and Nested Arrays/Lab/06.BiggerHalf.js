function biggerHalf(array) {
  array.sort((a, b) => a - b);
  let startIndex = array.length % 2 == 0 ? array.length / 2 : array.length / 2;
  let endIndex = array.length;
  array = array.slice(startIndex, endIndex);
  return array;
}
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));
