function evenPositionElement(input) {
  var resultArr = input.filter((x, index) => index % 2 == 0);
  let resultString = resultArr.join(" ");
  console.log(resultString);
}
evenPositionElement(["5", "10"]);
