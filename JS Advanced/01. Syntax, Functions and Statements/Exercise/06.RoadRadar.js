function roadRadar(speed, area) {
  const motorwayLimit = 130;
  const interstateLimit = 90;
  const cityLimit = 50;
  const residentialLimit = 20;
  let currentLimit = 0;
  let isInNormal = true;

  if (area == "city") {
    currentLimit = cityLimit;
    if (speed > cityLimit) {
      isInNormal = false;
    }
  } else if (area == "motorway") {
    currentLimit = motorwayLimit;
    if (speed > motorwayLimit) {
      isInNormal = false;
    }
  } else if (area == "interstate") {
    currentLimit = interstateLimit;
    if (speed > interstateLimit) {
      isInNormal = false;
    }
  } else if (area == "residential") {
    currentLimit = residentialLimit;
    if (speed > residentialLimit) {
      isInNormal = false;
    }
  }
  if (isInNormal) {
    console.log(`Driving ${speed} km/h in a ${currentLimit} zone`);
  } else {
    let difference = speed - currentLimit;
    console.log(
      `The speed is ${difference} km/h faster than the allowed speed of ${currentLimit} - ${
        difference <= 20
          ? "speeding"
          : difference <= 40
          ? "excessive speeding"
          : "reckless driving"
      }`
    );
  }
}
roadRadar(200, "motorway");
