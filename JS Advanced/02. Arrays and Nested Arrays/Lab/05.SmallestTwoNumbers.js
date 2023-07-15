function smallestTwoNumbers(array) {
  array = array.sort((a, b) => a - b).slice(0, 2);
  console.log(array.join(" "));
}
smallestTwoNumbers([3, 0, 10, 4, 7, 3]);
