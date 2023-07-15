function equalNeighbord(matrix) {
  let count = 0;
  for (let i = 0; i < matrix[0].length; i++) {
    for (let j = 0; j < matrix.length - 1; j++) {
      if (matrix[j][i] === matrix[j + 1][i]) {
        count++;
      }
      if (matrix[j][i] === matrix[j][i + 1]) {
        count++;
      }
      if (matrix[j][i] === matrix[j][i - 1]) {
        count++;
      }
    }
  }
  return count;
}
console.log(
  equalNeighbord([
    ["2", "2", "5", "7", "4"],
    ["4", "0", "5", "3", "4"],
    ["2", "5", "5", "4", "2"],
  ])
);
console.log(
  equalNeighbord([
    ["2", "3", "4", "7", "0"],
    ["4", "0", "5", "3", "4"],
    ["2", "3", "5", "4", "2"],
    ["9", "8", "7", "5", "4"],
  ])
);
console.log(
  equalNeighbord([
    ["test", "yes", "yo", "ho"],
    ["well", "done", "yo", "6"],
    ["not", "done", "yet", "5"],
  ])
);
