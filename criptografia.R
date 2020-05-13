library('httr')
library('stringr')
library('jsonlite')
library('digest')

url = "https://api.codenation.dev/v1/challenge/dev-ps/generate-data"

response <- GET(url, query = list(token = '0aea0ad17e72ed84d2eabbf2d04ea3caa3e86c5a'))
data <- content(response, type="application/json")

alfabeto <- c('a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z')

casas <- unlist(data["numero_casas"], use.names=F)
cifra <- str_to_lower(unlist(data["cifrado"], use.names=F))

result <- ''

for(c in strsplit(cifra, "")[[1]]) {
  if(!is.na(match(c, alfabeto))) {
    result <- str_c(result, alfabeto[((match(c, alfabeto)-casas)%%26)])
  } else {
    result <- str_c(result, c)
  }
}

data["decifrado"] <- result

dataJSON <- toJSON(data, pretty = T, auto_unbox = T)
write(dataJSON, 'answer.json')

sha1(result)
