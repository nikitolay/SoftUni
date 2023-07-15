function magicMatrives(matrix) {
  let result = true;
  for (let row = 0; row < matrix.length; row++) {
    let currentRowSum = matrix[row].reduce((a, b) => a + b);
    let currentColSum = 0;
    for (let col = 0; col < matrix.length; col++) {
      currentColSum += matrix[col][row];
    }
    if (currentColSum !== currentRowSum) {
      result = false;
      break;
    }
  }
  console.log(result);
}
magicMatrives([
  [1, 0, 0],
  [0, 0, 1],
  [0, 1, 0],
]);
