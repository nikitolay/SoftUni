function diagonalAttack(array) {
  let matrix = array.map((x) => x.split(" "));
  let resultMatrix = [];
  let sumOfFirstDiagonal = 0;
  let sumOfSecondDiagonal = 0;
  for (let i = 0; i < matrix.length; i++) {
    let firstNum = Number(matrix[i][i]);
    sumOfFirstDiagonal += firstNum;
  }
  for (let i = 0; i < matrix.length; i++) {
    let secondNum = Number(matrix[i][matrix.length - 1 - i]);
    sumOfSecondDiagonal += secondNum;
  }
  if (sumOfFirstDiagonal === sumOfSecondDiagonal) {
    for (let i = 0; i < matrix.length; i++) {
      let currentArray = [];
      for (let j = 0; j < matrix.length; j++) {
        if (j !== i) {
          if (j !== matrix.length - 1 - i) {
            matrix[i][j] = sumOfFirstDiagonal;
          }
        }
        currentArray.push(Number(matrix[i][j]));
      }
      resultMatrix.push(currentArray);
    }
    console.log(resultMatrix.join("\n").split(",").join(" "));
  } else {
    console.log(matrix.join("\n").split(",").join(" "));
  }
}
diagonalAttack([
  "5 3 12 3 1",
  "11 4 23 2 5",
  "101 12 3 21 10",
  "1 4 5 2 2",
  "5 22 33 11 1",
]);
diagonalAttack(["1 1 1", "1 1 1", "1 1 0"]);
