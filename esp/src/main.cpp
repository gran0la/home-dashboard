#include <Arduino.h>
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>
#include "secrets.h"

// ── Pin config ──
#define MOISTURE_PIN  34
#define RELAY_PIN     2

// ── Thresholds ──
#define DRY_THRESHOLD   2000
#define WET_THRESHOLD   1400

// ── Timing ──
#define PUMP_DURATION_MS    5000

void connectWifi() {
  Serial.print("Connecting to WiFi");
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  int attempts = 0;
  while (WiFi.status() != WL_CONNECTED && attempts < 20) {
    delay(500);
    Serial.print(".");
    attempts++;
  }
  if (WiFi.status() != WL_CONNECTED) {
    Serial.println("\nWiFi FAILED to connect!");
  } else {
    Serial.println("\nWiFi connected: " + WiFi.localIP().toString());
  }
}

void sendReading(int moisture) {
  if (WiFi.status() != WL_CONNECTED) return;

  HTTPClient http;
  http.begin(String(API_BASE_URL) + "/readings");
  http.addHeader("Content-Type", "application/json");

  JsonDocument doc;
  doc["plantId"]         = PLANT_ID;
  doc["moistureRaw"]     = moisture;
  doc["moisturePercent"] = map(moisture, 3300, 1295, 0, 100);

  String body;
  serializeJson(doc, body);

  int code = http.POST(body);
  Serial.println("POST /readings -> " + String(code));
  http.end();
}

void sendWaterEvent(double durationSeconds) {
  if (WiFi.status() != WL_CONNECTED) return;

  HTTPClient http;
  http.begin(String(API_BASE_URL) + "/waterevents");
  http.addHeader("Content-Type", "application/json");

  JsonDocument doc;
  doc["plantId"]         = PLANT_ID;
  doc["durationSeconds"] = durationSeconds;

  String body;
  serializeJson(doc, body);

  int code = http.POST(body);
  Serial.println("POST /waterevents -> " + String(code));
  http.end();
}

void setup() {
  Serial.begin(115200);
  delay(500);
  Serial.println("\n\n===== PLANT WATERER BOOTED =====");

  pinMode(RELAY_PIN, OUTPUT);
  digitalWrite(RELAY_PIN, HIGH);

  connectWifi();
}

void loop() {
  int total = 0;
  for (int i = 0; i < 5; i++) {
    total += analogRead(MOISTURE_PIN);
    delay(10);
  }
  int moisture = total / 5;

  Serial.println("──────────────────────");
  Serial.print("Moisture reading : ");
  Serial.println(moisture);

  sendReading(moisture);

  if (moisture > DRY_THRESHOLD) {
    Serial.println("DRY — running pump...");
    digitalWrite(RELAY_PIN, LOW);
    delay(PUMP_DURATION_MS);
    digitalWrite(RELAY_PIN, HIGH);
    Serial.println("Pump off.");
    sendWaterEvent(PUMP_DURATION_MS / 1000.0);
  } else {
    Serial.println("MOIST — no watering needed");
  }

  delay(300000); 
}
