function biggestElement(input) {
  let result = input.reduce((acc, c) => acc.concat(c));

  return result.reduce((a, b) => Math.max(a, b));
}
console.log(
  biggestElement([
    [20, 50, 10],
    [8, 33, 145],
  ])
);
