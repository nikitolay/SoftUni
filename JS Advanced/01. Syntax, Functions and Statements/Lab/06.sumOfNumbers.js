function sumOfNumbers(num1, num2) {
  let start = Number(num1);
  let end = Number(num2);
  let result = 0;
  for (let num = start; num <= end; num++) {
    result += num;
  }
  console.log(result);
}
