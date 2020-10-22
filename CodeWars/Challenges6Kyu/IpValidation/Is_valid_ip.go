package kata

import (
	"fmt"
	"regexp"
)

func Is_valid_ip(ip string) bool {

	digit := `(0|(1[0-9]?[0-9]?)|(2(([0-4]?[0-9]?)|(5?[0-5]?)))|([3-9][0-9]?))`
	ipv4Regex := fmt.Sprintf("^%s\\.%s\\.%s\\.%s$", digit, digit, digit, digit)
	matched, _ := regexp.MatchString(ipv4Regex, ip)

	fmt.Println(ipv4Regex)

	return matched
}
