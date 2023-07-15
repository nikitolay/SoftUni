function diagonalSums(matrix) {
  let firstDiagonalSum = 0;
  let secondDiagonalSum = 0;
  for (let i = 0; i < matrix.length; i++) {
    firstDiagonalSum += Number(matrix[i][i]);
  }
  for (let i = 0; i < matrix.length; i++) {
    secondDiagonalSum += Number(matrix[i][matrix.length - 1 - i]);
  }
  console.log(`${firstDiagonalSum} ${secondDiagonalSum}`);
}
diagonalSums([
  [20, 40],
  [10, 60],
]);
