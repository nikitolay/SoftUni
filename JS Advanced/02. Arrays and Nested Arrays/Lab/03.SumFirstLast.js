function sumFirstLast(array) {
  let firstNum = Number(array[0]);
  let secondNum = Number(array[array.length - 1]);
  return firstNum + secondNum;
}
console.log(sumFirstLast(['20', '30', '40']));
