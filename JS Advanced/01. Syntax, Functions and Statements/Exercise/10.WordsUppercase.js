function wordsUppercase(words) {
  const re = /\w+/g;
  let arr = words.match(re);
  let resultArr = arr.map((x) => x.toUpperCase());
  console.log(resultArr.join(", "));
}
wordsUppercase("Hi, how are you?");
