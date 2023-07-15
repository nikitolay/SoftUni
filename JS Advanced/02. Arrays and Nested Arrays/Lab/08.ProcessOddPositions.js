function processOddPositions(array) {
  array = array
    .filter((x, index) => index % 2 !== 0)
    .map((x) => x * 2)
    .reverse();
  return array.join(" ");
}
console.log(processOddPositions([3, 0, 10, 4, 7, 3]));
