function negativePositiveNumbers(array) {
  let result = [];
  for (const el of array) {
    let current = Number(el);
    if (current < 0) {
      result.unshift(current);
    } else {
      result.push(current);
    }
  }
  console.log(result.join("\n"));
}
negativePositiveNumbers([3, -2, 0, -1]);
