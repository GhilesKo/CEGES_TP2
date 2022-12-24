const PROXY_CONFIG = [
  {
    context: [
      "/auth/*",
      "/analyse/*",
      "/analyse/periodes/*",
    ],
    target: "https://localhost:7218",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
