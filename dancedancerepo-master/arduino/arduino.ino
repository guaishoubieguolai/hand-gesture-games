void setup() {
  Serial.begin(9600);
}

void loop() {
  if (Serial.available() > 0) {
    String command = Serial.readStringUntil('\n');
    
    if (command == "UP") {
      // Handle UP arrow
    } else if (command == "DOWN") {
      // Handle DOWN arrow
    } else if (command == "LEFT") {
      // Handle LEFT arrow
    } else if (command == "RIGHT") {
      // Handle RIGHT arrow
    }
  }
}
