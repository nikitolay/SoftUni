function sameNumbers(number) {
  let isSame = true;
  const num = number.toString();
  let digitToCompare = num[0];
  let sum = 0;
  for (let i = 0; i < num.length; i++) {
    sum += Number(num[i]);
    if (digitToCompare !== num[i]) {
      isSame = false;
    }
  }
  console.log(isSame);
  console.log(sum);
}
sameNumbers(2222222);
