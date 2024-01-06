int operand1 = 5;
int operand2 = 7;

void setup() {
  Serial.begin(9600);
}

void loop() {
  
  Serial.print(operand1);
  Serial.print(",");
  Serial.println(operand2);

  delay(1000); 
}
